using Newtonsoft.Json;

namespace LukeCowley.Business.Models
{
    public struct Metric
    {
        public double Average { get; set; }
        public int DataPointCount { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
