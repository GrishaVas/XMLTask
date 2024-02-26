using Services.Models.Enums;

namespace Services.Models.Xml
{
    public class CombinedSamplerStatus : CombinedStatus
    {
        public CombinedStatusType CombinedStatusType = CombinedStatusType.Sampler;
        public int Status { get; set; }
        public string Vial { get; set; }
        public int Volume { get; set; }
        public int MaximumInjectionVolume { get; set; }
        public string RackL { get; set; }
        public string RackR { get; set; }
        public bool Buzzer { get; set; }
        public int RackInf { get; set; }
    }
}
