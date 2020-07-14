using LukeCowley.Business.Data.Converters;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LukeCowley.Business.Data.Providers
{
    public class InSightDataProvider : IMarsWeatherDataProvider
    {
        private string _apiKey;
        public InSightDataProvider(string apiKey)
        {
            _apiKey = apiKey;
        }
        public async Task<string> GetData()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.nasa.gov");
            var result = await client.GetAsync($"/insight_weather/?api_key={_apiKey}&feedtype=json&ver=1.0");
            if (result.IsSuccessStatusCode) return await result.Content.ReadAsStringAsync();

            return string.Empty;
        }

        public async Task<IEnumerable<Sol>> GetRecentSolsAsync()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Sol>>(await GetData(), new InSightConverter());
        }
    }
}
