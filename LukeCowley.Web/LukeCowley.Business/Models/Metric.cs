namespace LukeCowley.Business.Models
{
    public class Metric : ModelBase
    {
        public double Average { get; set; }
        public int DataPointCount { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
