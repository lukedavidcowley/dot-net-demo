using LukeCowley.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Business.Data
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAsync();
        Task<bool> CreateOrUpdateAsync(T model);
        Task<int> CreateOrUpdateAsync(IEnumerable<T> models);
    }
}
