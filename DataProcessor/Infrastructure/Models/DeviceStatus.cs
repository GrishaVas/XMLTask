using System.ComponentModel.DataAnnotations;
using Services.Models.Xml;

namespace DataProcessor.Infrastructure.Models
{
    public class DeviceStatus
    {
        public Guid Id { get; set; }
        [MaxLength(1024)]
        public string ModuleCategoryID { get; set; }
        public int IndexWithinRole { get; set; }
        public Guid InstrumentStatusId { get; set; }
        public InstrumentStatus InstrumentStatus { get; set; }
        public Guid RapidControlStatusId { get; set; }
        public RapidControlStatus RapidControlStatus { get; set; }
    }
}
