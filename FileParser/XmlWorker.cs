using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Abstractions;
using Services.Implemantations;
using Services.Models.Enums;
using Services.Models.Xml;

public class XmlWorker : BackgroundService
{
    private readonly XmlReaderService _xmlReaderService;
    private readonly IMessageBrokerService _messageBrokerService;
    private readonly IConfiguration _conf;
    private readonly ILogger<XmlWorker> _logger;

    public XmlWorker(XmlReaderService xmlReaderService,
        IMessageBrokerService messageBrokerService,
        IConfiguration conf,
        ILogger<XmlWorker> logger)
    {
        _xmlReaderService = xmlReaderService;
        _messageBrokerService = messageBrokerService;
        _conf = conf;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!stoppingToken.IsCancellationRequested)
        {
            var files = _conf.GetSection("XmlFiles").Get<string[]>() ?? new string[0];

            foreach (var file in files)
            {
                try
                {
                    var instrumentStatus = _xmlReaderService.GetDataFromFile<InstrumentStatus>($"XMLs/{file}");

                    if (instrumentStatus != null)
                    {
                        changeModuleState(instrumentStatus);

                        var json = JsonConvert.SerializeObject(instrumentStatus);
                        _messageBrokerService.SendMessage(_conf["QueueName"] ?? "XMLQueue", json);

                        _logger.Log(LogLevel.Information, $"Message {file} has sent");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex.Message);
                }

                await Task.Delay(1000, stoppingToken);
            }

            _logger.Log(LogLevel.Information, "Files have sent");
        }
    }

    private void changeModuleState(InstrumentStatus instrumentStatus)
    {
        foreach (var dStatuses in instrumentStatus.DeviceStatuses)
        {
            var moduleStateValues = Enum.GetValues(typeof(ModuleState));
            var moduleState = (ModuleState?)moduleStateValues?.GetValue(new Random().Next(moduleStateValues.Length)) ?? ModuleState.Offline;

            if (dStatuses.RapidControlStatus != null)
            {
                dStatuses.RapidControlStatus.CombinedStatus.ModuleState = moduleState;
            }
        }
    }
}
