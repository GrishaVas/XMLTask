using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Abstractions;
using Services.Implemantations;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(b =>
    {
        b.AddJsonFile("appsettings.json");
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<XmlWorker>();
        services.AddScoped<XmlReaderService>();
        services.AddSingleton<IMessageBrokerService, RabbitMQMessageBrokerService>();
    })
    .Build();

host.Run();
