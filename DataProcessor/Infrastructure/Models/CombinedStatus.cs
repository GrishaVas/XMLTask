using System.ComponentModel.DataAnnotations;
using Services.Models.Enums;

namespace DataProcessor.Infrastructure.Models
{
    public class CombinedStatus
    {
        public Guid Id { get; set; }
        [MaxLength(1024)]
        public string ModuleState { get; set; }
        public bool IsBusy { get; set; }
        public bool IsReady { get; set; }
        public bool IsError { get; set; }
        public bool KeyLock { get; set; }

        public int? Status { get; set; }
        [MaxLength(1024)]
        public string? Vial { get; set; }
        public int? Volume { get; set; }
        public int? MaximumInjectionVolume { get; set; }
        [MaxLength(1024)]
        public string? RackL { get; set; }
        [MaxLength(1024)]
        public string? RackR { get; set; }
        public bool? Buzzer { get; set; }
        public int? RackInf { get; set; }

        public string? Mode { get; set; }
        public int? Flow { get; set; }
        public decimal? PercentB { get; set; }
        public decimal? PercentC { get; set; }
        public decimal? PercentD { get; set; }
        public int? MinimumPressureLimit { get; set; }
        public int? Pressure { get; set; }
        public bool? PumpOn { get; set; }
        public int? Channel { get; set; }

        public bool? UseTemperatureControl { get; set; }
        public bool? OvenOn { get; set; }
        [MaxLength(1024)]
        public string? Temperature_Actual { get; set; }
        [MaxLength(1024)]
        public string? Temperature_Room { get; set; }
        public int? MaximumTemperatureLimit { get; set; }
        public int? Valve_Position { get; set; }
        public int? Valve_Rotations { get; set; }

        public CombinedStatusType CombinedStatusType { get; set; }

        public Guid RapidControlStatusId { get; set; }
        public RapidControlStatus RapidControlStatus { get; set; }
    }
}
