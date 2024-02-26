using DataProcessor.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataProcessor.Infrastructure.Configurations
{
    public class DeviceStatusConfiguration : IEntityTypeConfiguration<DeviceStatus>
    {
        public void Configure(EntityTypeBuilder<DeviceStatus> builder)
        {
            builder
                .HasOne(ds => ds.RapidControlStatus)
                .WithOne(rcs => rcs.DeviceStatus)
                .HasForeignKey<RapidControlStatus>(rcs => rcs.DeviceStatusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
