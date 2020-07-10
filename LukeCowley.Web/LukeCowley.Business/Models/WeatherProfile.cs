using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Business.Models
{
    public class WeatherProfile : ModelBase
    {
        Metric Temperature { get; set; }
        Metric WindSpeed { get; set; }
        Metric Pressure { get; set; }
        WindDirection WindDirection { get; set; }
    }
}
