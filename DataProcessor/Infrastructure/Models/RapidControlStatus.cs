
namespace DataProcessor.Infrastructure.Models
{
    public class RapidControlStatus
    {
        public Guid Id { get; set; }
        public Guid CombinedStatusId { get; set; }
        public CombinedStatus CombinedStatus { get; set; }
        public Guid DeviceStatusId { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
    }
}
