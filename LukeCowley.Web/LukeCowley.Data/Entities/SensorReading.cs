namespace LukeCowley.Data.Entities
{
    public class SensorReading : EntityBase
    {
        public Sol Sol { get; set; }
        public string Key { get; set; }
        public double Average { get; set; }
        public int DataPointCount { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
