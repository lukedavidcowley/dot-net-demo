namespace LukeCowley.Business.Models
{
    public enum MetricKeys
    {
        Unspecified,
        Temperature,
        WindSpeed,
        Pressure
    }

    public static class AcceptedMetricKeysExtensions
    {
        public static string ToKeyString(this MetricKeys key)
        {
            switch (key)
            {
                case MetricKeys.Pressure:
                    return "PRE";
                case MetricKeys.WindSpeed:
                    return "HWS";
                case MetricKeys.Temperature:
                    return "AT";
                case MetricKeys.Unspecified:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
        public static MetricKeys ToMetricKey(this string key)
        {
            switch (key)
            {
                case "PRE":
                    return MetricKeys.Pressure;
                case "HWS":
                    return MetricKeys.WindSpeed;
                case "AT":
                    return MetricKeys.Temperature;
                default:
                    return MetricKeys.Unspecified;
            }
        }
    }
}
