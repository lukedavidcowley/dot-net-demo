using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Business.Data.Providers
{
    public interface IMarsWeatherDataProvider : IDataProvider
    {
        Task<IEnumerable<Sol>> GetRecentSolsAsync();
    }
}
