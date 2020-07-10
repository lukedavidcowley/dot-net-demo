using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Business.Models
{
    public class WeatherProfile : ModelBase
    {
        public Metric Temperature { get; set; }
        public Metric WindSpeed { get; set; }
        public Metric Pressure { get; set; }
        public WindDirection WindDirection { get; set; }
    }
}
