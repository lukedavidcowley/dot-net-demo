using LukeCowley.Business.Data;
using LukeCowley.Business.Data.Providers;
using LukeCowley.Business.Models;
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

        public async Task<IEnumerable<Sol>> GetSolsAsync()
        {
            return await _solRepository.GetQueryable()
                .OrderByDescending(s => s.Number)
                .Take(7)
                .ToListAsync();
        }

        public async Task<bool> UpdateWeatherAsync()
        {
            if(await _solRepository
                .CreateOrUpdateAsync(await _weatherDataProvider.GetRecentSolsAsync()))
            {
                await _solRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
