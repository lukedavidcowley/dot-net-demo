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
        private readonly IRepository<Sol> _solRepository;
        private readonly IMarsWeatherDataProvider _weatherDataProvider;
        public MarsWeatherService(IRepository<Sol> repository, IMarsWeatherDataProvider dataProvider)
        {
            _solRepository = repository;
            _weatherDataProvider = dataProvider;
        }

        public async Task<IEnumerable<Sol>> GetSolsAsync()
        {
            return await _solRepository.GetAsync();
        }

        public async Task<bool> UpdateWeatherAsync()
        {
            return await _solRepository
                .UpdateAsync(await _weatherDataProvider.GetRecentSolsAsync());
        }
    }
}
