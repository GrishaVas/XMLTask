using Services.Models.Enums;

namespace Services.Models.Xml
{
    public class CombinedOvenStatus : CombinedStatus
    {
        public CombinedStatusType CombinedStatusType = CombinedStatusType.Oven;
        public bool UseTemperatureControl { get; set; }
        public bool OvenOn { get; set; }
        public string Temperature_Actual { get; set; }
        public string Temperature_Room { get; set; }
        public int MaximumTemperatureLimit { get; set; }
        public int Valve_Position { get; set; }
        public int Valve_Rotations { get; set; }
        public bool Buzzer { get; set; }
    }
}
