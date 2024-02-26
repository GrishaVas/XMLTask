using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataProcessor.Infrastructure
{
    public class DataProcessorContextFactory : IDesignTimeDbContextFactory<DataProcessorDbContext>
    {
        public DataProcessorDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var contextOptions = new DbContextOptionsBuilder<DataProcessorDbContext>()
                .UseSqlite(config["SqLiteConnectionString"])
                .Options;

            return new DataProcessorDbContext(contextOptions);
        }
    }
}
