namespace LukeCowley.Data.Entities
{
    public class SensorReading : EntityBase
    {
        public string MetricName { get; set; }
        public double Average { get; set; }
        public int DataPointCount { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
