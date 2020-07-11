using LukeCowley.Business.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LukeCowley.Business.Data.Converters
{
    public class InSightConverter : JsonConverter<IEnumerable<Sol>>
    {
        public override bool CanWrite => false;

        public override IEnumerable<Sol> ReadJson(JsonReader reader, Type objectType, [AllowNull] IEnumerable<Sol> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var sols = new List<Sol>();

            var token = JObject.Load(reader);
            foreach (var obj in (JArray)token["sol_keys"])
            {
                var key = obj.Value<string>();
                var data = token[key];

                //weather profile
                var profile = new WeatherProfile();
                foreach (JProperty prop in data.Values<JProperty>())
                {
                    var result = prop?.First;

                    if(TryMakeMetric(result, out var metric))
                    {
                        switch (prop.Name)
                        {
                            case "AT":
                                profile.Temperature = metric;
                                break;
                            case "HWS":
                                profile.WindSpeed = metric;
                                break;
                            case "PRE":
                                profile.Pressure = metric;
                                break;
                            default:
                                break;
                        }
                    }
                    else if(prop.Name == "WD")
                    {
                        profile.WindDirection = (WindDirection)(Enum.Parse(typeof(WindDirection), result["most_common"]["compass_point"].Value<string>()));
                    }
                }

                var sol = new Sol
                {
                    Name = obj.ToString(), 
                    StartDate = data["First_UTC"].Value<DateTime>(),
                    EndDate = data["Last_UTC"].Value<DateTime>(),
                    WeatherProfile = profile
                };
                sols.Add(sol);
            }
            return sols;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] IEnumerable<Sol> value, JsonSerializer serializer)
        {
            throw new NotImplementedException("InSight Converter cannot write json");
        }
        private static bool TryMakeMetric(JToken token, out Metric metric)
        {
            try
            {
                metric = new Metric
                {
                    Average = token["av"]?.Value<double>() ?? throw new Exception("no av prop"),
                    DataPointCount = token["ct"]?.Value<int>() ?? throw new Exception("no ct prop"),
                    Maximum = token["mx"]?.Value<double>() ?? throw new Exception("no mx prop"),
                    Minimum = token["mn"]?.Value<double>() ?? throw new Exception("no mn prop")
                };
                return true;
            }
            catch(Exception ex)
            {
                metric = default;
                return false;
            }
        }
    }
}
