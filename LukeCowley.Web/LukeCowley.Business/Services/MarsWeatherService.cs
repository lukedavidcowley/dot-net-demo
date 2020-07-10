using LukeCowley.Business.Data;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LukeCowley.Business.Services
{
    public class MarsWeatherService : IMarsWeatherService
    {
        private readonly IRepository<WeatherProfile> _weatherRepository;
        private readonly IMarsWeatherDataProvider _weatherDataProvider;
        public MarsWeatherService(IRepository<WeatherProfile> repository, IMarsWeatherDataProvider dataProvider)
        {
            _weatherRepository = repository;
            _weatherDataProvider = dataProvider;
        }

        public async Task<IEnumerable<WeatherProfile>> GetWeatherProfileAsync()
        {
            return await _weatherRepository.GetAsync();
        }

        public async Task<bool> UpdateWeatherAsync()
        {
            var sols = await _weatherDataProvider.GetRecentSolsAsync();
            throw new NotImplementedException();
        }
    }
}
