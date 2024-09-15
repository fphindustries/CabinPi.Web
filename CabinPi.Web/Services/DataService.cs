using System.Data;
using MySqlConnector;
using System.Diagnostics.Metrics;

namespace CabinPi.Web.Services
{
    public class DataService
    {
        private readonly MySqlDataSource _dataSource;

        public DataService(MySqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<Measurement?> GetMostRecentMeasurement()
        {
            await using var connection = await _dataSource.OpenConnectionAsync();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM measurements ORDER BY Date DESC LIMIT 1";
            await using var reader = await command.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
            {
                return null;
            }

            return new Measurement
            {
                Date = reader.GetDateTime("Date"),
                AbsorbTime = reader.Get<int?>("AbsorbTime"),
                AmpHours = reader.Get<int?>("AmpHours"),
                EqualizeTime = reader.Get<int?>("EqualizeTime"),
                FloatTime = reader.Get<int?>("FloatTime"),
                HighestVinputLog = reader.Get<float?>("HighestVinputLog"),
                IbattDisplay = reader.Get<float?>("IbattDisplay"),
                NiteMinutesNoPwr = reader.Get<int?>("NiteMinutesNoPwr"),
                PvInputCurrent = reader.Get<float?>("PvInputCurrent"),
                VocLastMeasured = reader.Get<float?>("VocLastMeasured"),
                BatteryState = reader.Get<int?>("BatteryState"),
                ChargeState = reader.Get<int?>("ChargeState"),
                ClassicState = reader.Get<int?>("ClassicState"),
                DispavgVbatt = reader.Get<float?>("DispavgVbatt"),
                DispavgVpv = reader.Get<float?>("DispavgVpv"),
                kWHours = reader.Get<float?>("kWHours"),
                Watts = reader.Get<int?>("Watts"),
                Case_C = reader.Get<float?>("Case_C"),
                Case_F = reader.Get<float?>("Case_F"),
                Ext_C = reader.Get<float?>("Ext_C"),
                Ext_F = reader.Get<float?>("Ext_F"),
                hPa = reader.Get<float?>("hPa"),
                Humidity = reader.Get<float?>("Humidity"),
                inHg = reader.Get<float?>("inHg"),
                Int_C = reader.Get<float?>("Int_C"),
                Int_F = reader.Get<float?>("Int_F"),
                InverterOn = reader.IsDBNull("InverterOn") ? false : reader.GetBoolean("InverterOn"),
                InverterMode = reader.Get<int?>("InverterMode"),
                InverterFault = reader.Get<int?>("InverterFault"),
                InverterVACOut = reader.Get<float?>("InverterVACOut"),
                InverterAACOut = reader.Get<float?>("InverterAACOut"),
                WindAverage = reader.Get<float?>("wind_avg"),
                WindGust = reader.Get<float?>("wind_gust"),
                WindDirection = reader.Get<int?>("wind_direction"),
                Illuminance = reader.Get<int?>("illuminance"),
                UVIndex = reader.Get<float?>("uv"),
                SolarRadiation = reader.Get<int?>("solar_radiation"),
                RainRate = reader.Get<float?>("rain"),
                AverageStrikeDistance = reader.Get<float?>("avg_strike_distance"),
                StrikeCount = reader.Get<int?>("strike_count"),
                WeatherBattery = reader.Get<float?>("weather_battery"),
                DailyAccumulation = reader.Get<float?>("daily_accumulation"),
                ExternalHumidity = reader.Get<float?>("ext_humidity"),
            };
        }

        public async Task<MeasurementHistory?> GetMeasurmentHistory()
        {
            await using var connection = await _dataSource.OpenConnectionAsync();
            await using var command = connection.CreateCommand();
            command.CommandText = "SELECT " +
                "DATE_FORMAT(DATE, '%y%m%d%H') AS Date, " +
                "MAX(DispavgVpv) AS DispavgVpv, " +
                "MAX(DispavgVbatt) AS DispavgVbatt, " +
                "MAX(AmpHours) AS AmpHours, " +
                "MAX(Ext_F) AS Ext_F, " +
                "MAX(Int_F) AS Int_F, " +
                "MAX(Humidity) AS Humidity, " +
                "MAX(ext_humidity) AS ext_humidity, " +
                "MAX(inHg) AS inHg, " +
                "MAX(wind_avg) AS wind_avg, " +
                "MAX(wind_gust) AS wind_gust, " +
                "AVG(wind_direction) AS wind_direction, " +
                "MAX(rain) AS rain, " +
                "MAX(daily_accumulation) AS daily_accumulation, " +
                "MAX(strike_count) AS strike_count, " +
                "MAX(avg_strike_distance) AS avg_strike_distance " +
                "FROM measurements GROUP BY DATE_FORMAT(DATE, '%y%m%d%H') ORDER BY DATE DESC LIMIT 24";
            await using var reader = await command.ExecuteReaderAsync();
            var history = new MeasurementHistory();
            while(await reader.ReadAsync())
            {
                history.PanelVoltage.Add(reader.Get<float?>("DispavgVpv"));
                history.BatteryVoltage.Add(reader.Get<float?>("DispavgVbatt"));
                history.AmpHours.Add(reader.Get<int?>("AmpHours"));
                history.OutsideTemp.Add(reader.Get<float?>("Ext_F"));
                history.InsideTemp.Add(reader.Get<float?>("Int_F"));
                history.InsideHumidity.Add(reader.Get<float?>("Humidity"));
                history.OutsideHumidity.Add(reader.Get<float?>("ext_humidity"));
                history.Pressure.Add(reader.Get<float?>("inHg"));
                history.WindSpeed.Add(reader.Get<float?>("wind_avg"));
                history.WindGust.Add(reader.Get<float?>("wind_gust"));
                history.WindDirection.Add((int)Math.Round(reader.Get<float?>("wind_direction").GetValueOrDefault()));
                history.RainRate.Add(reader.Get<float?>("rain"));
                history.DailyAccumulation.Add(reader.Get<float?>("daily_accumulation"));
                history.StrikeCount.Add(reader.Get<int?>("strike_count"));
                history.StrikeDistance.Add(reader.Get<float?>("avg_strike_distance"));

            }
            return history;
        }

    }
}
