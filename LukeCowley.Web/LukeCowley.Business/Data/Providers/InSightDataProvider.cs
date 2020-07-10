using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Business.Data.Providers
{
    public class InSightDataProvider : IMarsWeatherDataProvider
    {
        private string _endPoint;
        public InSightDataProvider(string dataSourceUrl, string apiKey)
        {
            _endPoint = $"{dataSourceUrl}?api_key={apiKey}";
        }
        public async Task<string> GetData()
        {
            using var client = new HttpClient();
            var result = await client.GetAsync(_endPoint);
            if (result.IsSuccessStatusCode) return await result.Content.ReadAsStringAsync();

            return string.Empty;
        }

        public async Task<IEnumerable<Sol>> GetRecentSolsAsync()
        {
            var json = GetData();
            var obj = new JObject(json);
            //ar test = JsonConvert.DeserializeObject<IEnumerable<Sol>>(GetData(), )
            throw new NotImplementedException();
        }
    }
}
