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
        Task<Guid> CreateAsync(T model);
        Task<T> GetByIdAsync(Guid Id);
        Task<IQueryable<T>> GetAsync();
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync();
    }
}
