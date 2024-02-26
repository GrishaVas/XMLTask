using DataProcessor.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataProcessor.Infrastructure.Configurations
{
    public class RapidControlStatusConfiguration : IEntityTypeConfiguration<RapidControlStatus>
    {
        public void Configure(EntityTypeBuilder<RapidControlStatus> builder)
        {
            builder
                .HasOne(rcs => rcs.CombinedStatus)
                .WithOne(cs => cs.RapidControlStatus)
                .HasForeignKey<CombinedStatus>(cs => cs.RapidControlStatusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
