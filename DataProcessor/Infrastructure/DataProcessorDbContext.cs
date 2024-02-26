using DataProcessor.Infrastructure.Configurations;
using DataProcessor.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProcessor.Infrastructure
{
    public class DataProcessorDbContext : DbContext
    {
        public DataProcessorDbContext(DbContextOptions<DataProcessorDbContext> options) : base(options)
        {
        }

        public DbSet<InstrumentStatus> InstrumentStatuses { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<RapidControlStatus> RapidControlStatuses { get; set; }
        public DbSet<CombinedStatus> CombinedStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(InstrumentStatusConfiguration).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(DeviceStatusConfiguration).Assembly)
                .ApplyConfigurationsFromAssembly(typeof(RapidControlStatusConfiguration).Assembly);
        }
    }
}
