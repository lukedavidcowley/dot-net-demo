using LukeCowley.Business.Models;
using System.Collections.Generic;
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
