namespace CabinPi.Web.Services
{
    public class MeasurementHistory
    {
        public List<float?> PanelVoltage { get; set; } = new List<float?>();
        public List<float?> BatteryVoltage { get; set; } = new List<float?>();
        public List<int?> AmpHours { get; set; } = new List<int?>();
        public List<float?> InsideTemp { get; set; } = new List<float?>();
        public List<float?> OutsideTemp { get; set; } = new List<float?>();
        public List<float?> InsideHumidity { get; set; } = new List<float?>();
        public List<float?> OutsideHumidity { get; set; } = new List<float?>();
        public List<float?> Pressure { get; set; } = new List<float?>();
        public List<float?> WindSpeed { get; set; } = new List<float?>();
        public List<float?> WindGust { get; set; } = new List<float?>();
        public List<int?> WindDirection { get; set; } = new List<int?>();
        public List<float?> RainRate { get; set; } = new List<float?>();
        public List<float?> DailyAccumulation { get; set; } = new List<float?>();
        public List<float?> StrikeCount { get; set; } = new List<float?>();
        public List<float?> StrikeDistance { get; set; } = new List<float?>();
        
    }
}
