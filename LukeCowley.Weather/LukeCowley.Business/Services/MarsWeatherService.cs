using LukeCowley.Business.Data;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Sol>> GetSolWeekAsync()
        {
            return (await _solRepository.GetAsync())
                .Take(7)
                .OrderByDescending(s => s.Number)
                .ToList();
        }

        public async Task<bool> UpdateWeatherAsync()
        {
            var data = await _weatherDataProvider.GetRecentSolsAsync();
            return await _solRepository.CreateOrUpdateAsync(data) == data.Count();
        }
    }
}
