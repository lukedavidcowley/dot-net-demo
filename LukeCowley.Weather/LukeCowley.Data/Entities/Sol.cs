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
        public virtual ICollection<SensorReading> Readings { get; set; }

        public Sol() : base() { }

        public static explicit operator Sol(Business.Models.Sol sol)
        {
            return null;
        }


        public static implicit operator Business.Models.Sol(Sol sol)
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
                        Average = pressure?.Average ?? default,
                        DataPointCount = pressure?.DataPointCount ?? default,
                        Maximum = pressure?.Maximum ?? default,
                        Minimum = pressure?.Minimum ?? default
                    },
                    Temperature = new Metric
                    {
                        Average = temperature?.Average ?? default,
                        DataPointCount = temperature?.DataPointCount ?? default,
                        Maximum = temperature?.Maximum ?? default,
                        Minimum = temperature?.Minimum ?? default
                    },
                    WindDirection = sol.AverageWindDirection,
                    WindSpeed = new Metric
                    {
                        Average = windSpeed?.Average ?? default, 
                        DataPointCount = windSpeed?.DataPointCount ?? default,
                        Maximum = windSpeed?.Maximum ?? default,
                        Minimum = windSpeed?.Minimum ?? default
                    }
                }
            };
        }

        private static SensorReading GetMostRecentReadingByKey(ICollection<SensorReading> readings, MetricKeys key)
        {
            return readings?
                .Where(r => r.Key.ToMetricKey() == key)
                .OrderByDescending(r => r.UpdatedOn)
                .FirstOrDefault();
        }
    }
}
