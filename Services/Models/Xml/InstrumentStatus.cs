using System.Xml.Serialization;

namespace Services.Models.Xml
{
    [XmlType("InstrumentStatus")]
    public class InstrumentStatus
    {
        public string PackageID { get; set; }
        [XmlElement("DeviceStatus")]
        public DeviceStatus[] DeviceStatuses { get; set; }
    }
}
