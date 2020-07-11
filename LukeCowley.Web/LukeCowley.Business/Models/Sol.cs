using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Business.Models
{
    public class Sol : ModelBase
    {
        public int Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeatherProfile WeatherProfile { get; set; }
    }
}
