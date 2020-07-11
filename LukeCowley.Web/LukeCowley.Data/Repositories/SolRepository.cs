using LukeCowley.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Data.Repositories
{
    public class SolRepository : IRepository<Business.Models.Sol>
    {
        public Task<Guid> CreateAsync(Business.Models.Sol model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Business.Models.Sol>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Business.Models.Sol> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Business.Models.Sol model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IEnumerable<Business.Models.Sol> models)
        {
            throw new NotImplementedException();
        }
    }
}
