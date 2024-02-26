using System.Xml.Serialization;

namespace Services.Models.Xml
{
    [XmlType("DeviceStatus")]
    public class DeviceStatus
    {
        public string ModuleCategoryID { get; set; }
        public int? IndexWithinRole { get; set; }
        public RapidControlStatus? RapidControlStatus { get; set; }
    }
}
