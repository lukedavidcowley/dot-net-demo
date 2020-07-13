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
        IQueryable<T> Get();
        Task<bool> CreateOrUpdate(T model);
        Task<int> CreateOrUpdate(IEnumerable<T> models);
    }
}
