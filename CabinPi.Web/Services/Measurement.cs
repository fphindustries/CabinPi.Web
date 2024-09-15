namespace CabinPi.Web.Services
{
    public class Measurement
    {
        public DateTime Date { get; set; }
        public int? AbsorbTime { get; set; }
        public int? AmpHours { get; set; }
        public int? EqualizeTime { get; set; }
        public int? FloatTime { get; set; }
        public float? HighestVinputLog { get; set; }
        public float? IbattDisplay { get; set; }
        public int? NiteMinutesNoPwr { get; set; }
        public float? PvInputCurrent { get; set; }
        public float? VocLastMeasured { get; set; }
        public int? BatteryState { get; set; }
        public int? ChargeState { get; set; }
        public int? ClassicState { get; set; }
        public float? DispavgVbatt { get; set; }
        public float? DispavgVpv { get; set; }
        public float? kWHours { get; set; }
        public int? Watts { get; set; }
        public float? Case_C { get; set; }
        public float? Case_F { get; set; }
        public float? Ext_C { get; set; }
        public float? Ext_F { get; set; }
        public float? hPa { get; set; }
        public float? Humidity { get; set; }
        public float? inHg { get; set; }
        public float? Int_C { get; set; }
        public float? Int_F { get; set; }
        public bool? InverterOn { get; set; }
        public int? InverterMode { get; set; }
        public int? InverterFault { get; set; }
        public float? InverterVACOut { get; set; }
        public float? InverterAACOut { get; set; }
        public float? WindAverage { get; set; }
        public float? WindGust { get; set; }
        public int? WindDirection { get; set; }
        public int? Illuminance { get; set; }
        public float? UVIndex { get; set; }
        public int? SolarRadiation { get; set; }
        public float? RainRate { get; set; }
        public float? AverageStrikeDistance { get; set; }
        public int? StrikeCount { get; set; }
        public float? WeatherBattery { get; set; }
        public float? DailyAccumulation { get; set; }
        public float? ExternalHumidity { get; set; }
        public string BatteryStateDescription
        {
            get
            {
                return BatteryState switch
                {
                    0 => "Resting",
                    3 => "Absorb",
                    4 => "Bulk MPPT",
                    5 => "Float",
                    6 => "Float MPPT",
                    7 => "Equalize",
                    10 => "Hyper VOC",
                    18 => "Equalize MPPT",
                    _ => "Unknown",
                };
            }

        }

        public string InverterModeStatus
        {
            get
            {
                return InverterMode switch
                {
                    0x00 => "Standby",
                    0x01 => "Equalize",
                    0x02 => "Float",
                    0x04 => "Absorb",
                    0x08 => "Bulk",
                    0x09 => "Battery Saver",
                    0x10 => "Charging",
                    0x20 => "Off",
                    0x40 => "Inverting",
                    0x50 => "Standby",
                    0x80 => "Searching",
                    _ => "Unknown",
                };
            }
        }

        public string WindCardinalDirection
        {
            get
            {
                if (WindDirection.HasValue)
                {
                    int direction = WindDirection.Value % 360;
                    if (direction >= 337.5 || direction < 22.5)
                        return "N";
                    else if (direction >= 22.5 && direction < 67.5)
                        return "NE";
                    else if (direction >= 67.5 && direction < 112.5)
                        return "E";
                    else if (direction >= 112.5 && direction < 157.5)
                        return "SE";
                    else if (direction >= 157.5 && direction < 202.5)
                        return "S";
                    else if (direction >= 202.5 && direction < 247.5)
                        return "SW";
                    else if (direction >= 247.5 && direction < 292.5)
                        return "W";
                    else
                        return "NW";
                }
                else
                {
                    return "Unknown";
                }
            }
        }
    }
}
