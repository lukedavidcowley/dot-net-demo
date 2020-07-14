using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LukeCowley.Data.Entities
{
    public class Sol : EntityBase
    {
        public int Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WindDirection AverageWindDirection { get; set; }
        public ICollection<SensorReading> Readings { get; set; } = new List<SensorReading>();

        public Sol() : base() { }

        public static explicit operator Business.Models.Sol(Sol sol)
        {
            var pressure = GetMostRecentReadingByKey(sol.Readings, MetricKeys.Pressure);
            var temperature = GetMostRecentReadingByKey(sol.Readings, MetricKeys.Temperature);
            var windSpeed = GetMostRecentReadingByKey(sol.Readings, MetricKeys.WindSpeed);

            return new Business.Models.Sol
            {
                Number = sol.Number,
                EndDate = sol.EndDate,
                StartDate = sol.StartDate,
                WeatherProfile = new WeatherProfile
                {
                    Pressure = new Metric
                    {
                        Average = pressure.Average,
                        DataPointCount = pressure.DataPointCount,
                        Maximum = pressure.Maximum,
                        Minimum = pressure.Minimum
                    },
                    Temperature = new Metric
                    {
                        Average = temperature.Average,
                        DataPointCount = temperature.DataPointCount,
                        Maximum = temperature.Maximum,
                        Minimum = temperature.Minimum
                    },
                    WindDirection = sol.AverageWindDirection,
                    WindSpeed = new Metric
                    {
                        Average = windSpeed.Average,
                        DataPointCount = windSpeed.DataPointCount,
                        Maximum = windSpeed.Maximum,
                        Minimum = windSpeed.Minimum
                    }
                }
            };
        }

        private static SensorReading GetMostRecentReadingByKey(ICollection<SensorReading> readings, MetricKeys key)
        {
            return readings
                .Where(r => r.Key.ToMetricKey() == key)
                .OrderByDescending(r => r.UpdatedOn)
                .FirstOrDefault();
        }
    }
}
