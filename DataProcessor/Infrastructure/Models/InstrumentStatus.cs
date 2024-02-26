using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace DataProcessor.Infrastructure.Models
{
    public class InstrumentStatus
    {
        public Guid Id { get; set; }
        [MaxLength(1024)]
        public string PackageID { get; set; }
        public List<DeviceStatus> DeviceStatuses { get; set; }
    }
}
