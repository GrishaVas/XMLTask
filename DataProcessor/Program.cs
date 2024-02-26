using System.Text;
using System.Text.Json;
using DataProcessor.Infrastructure;
using DataProcessor.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Implemantations;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var messageBroker = new RabbitMQMessageBrokerService(config);
var contextOptions = new DbContextOptionsBuilder<DataProcessorDbContext>()
    .UseSqlite(config["SqLiteConnectionString"])
    .Options;
var dbContext = new DataProcessorDbContext(contextOptions);

dbContext.Database.Migrate();

messageBroker.OnRecieveMessage("Xml", (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    var instrumentStatus = JsonSerializer.Deserialize<InstrumentStatus>(message);

    if (instrumentStatus != null && !dbContext.InstrumentStatuses.Any(@is => @is.PackageID == instrumentStatus.PackageID))
    {
        dbContext.InstrumentStatuses.Add(instrumentStatus);
        dbContext.SaveChanges();
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Recieved Message:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"    {message}");
});

Console.Read();