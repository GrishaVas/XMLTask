using Services.Models.Enums;

namespace Services.Models.Xml
{
    public class CombinedPumpStatus : CombinedStatus
    {
        public CombinedStatusType CombinedStatusType = CombinedStatusType.Pump;
        public string Mode { get; set; }
        public int Flow { get; set; }
        public decimal PercentB { get; set; }
        public decimal PercentC { get; set; }
        public decimal PercentD { get; set; }
        public int MinimumPressureLimit { get; set; }
        public int Pressure { get; set; }
        public bool PumpOn { get; set; }
        public int Channel { get; set; }
    }
}
