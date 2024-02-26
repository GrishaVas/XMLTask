using DataProcessor.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataProcessor.Infrastructure.Configurations
{
    internal class InstrumentStatusConfiguration : IEntityTypeConfiguration<InstrumentStatus>
    {
        public void Configure(EntityTypeBuilder<InstrumentStatus> builder)
        {
            builder
                .HasMany(@is => @is.DeviceStatuses)
                .WithOne(ds => ds.InstrumentStatus)
                .HasForeignKey(ds => ds.InstrumentStatusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
