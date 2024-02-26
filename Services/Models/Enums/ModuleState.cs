using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Services.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModuleState
    {
        [EnumMember(Value = "Online")]
        [XmlEnum(Name = "Online")]
        Online = 0,
        [EnumMember(Value = "Run")]
        [XmlEnum(Name = "Run")]
        Run,
        [EnumMember(Value = "NotReady")]
        [XmlEnum(Name = "NotReady")]
        NotReady,
        [EnumMember(Value = "Offline")]
        [XmlEnum(Name = "Offline")]
        Offline
    }
}
