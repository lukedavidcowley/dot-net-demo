using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;

namespace LukeCowley.Data.Entities
{
    public class Sol
    {
        public int Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WindDirection AverageWindDirection { get; set; }
        public ICollection<SensorReading> Readings { get; set; }
    }
}
