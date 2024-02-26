using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Services.Models.Enums;

namespace Services.Models.Xml
{
    [XmlInclude(typeof(CombinedSamplerStatus))]
    [XmlInclude(typeof(CombinedOvenStatus))]
    [XmlInclude(typeof(CombinedPumpStatus))]
    [JsonDerivedType(typeof(CombinedSamplerStatus))]
    [JsonDerivedType(typeof(CombinedOvenStatus))]
    [JsonDerivedType(typeof(CombinedPumpStatus))]
    public abstract class CombinedStatus
    {
        public ModuleState ModuleState { get; set; }
        public bool IsBusy { get; set; }
        public bool IsReady { get; set; }
        public bool IsError { get; set; }
        public bool KeyLock { get; set; }
    }
}
