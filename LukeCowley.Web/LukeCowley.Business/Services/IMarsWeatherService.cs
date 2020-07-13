using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Business.Services
{
    public interface IMarsWeatherService
    {
        Task<IEnumerable<Sol>> GetSolsAsync();
        Task<bool> UpdateWeatherAsync();
    }
}
