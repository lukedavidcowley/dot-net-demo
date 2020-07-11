using LukeCowley.Business.Data.Converters;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
            return JsonConvert.DeserializeObject<IEnumerable<Sol>>(await GetData(), new InSightConverter());
        }
    }
}
