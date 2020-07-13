using LukeCowley.Business.Data;
using LukeCowley.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeCowley.Data.Repositories
{
    public class SolWeekRepository : IRepository<Business.Models.Sol>
    {
        private readonly MarsWeatherContext _context;
        public SolWeekRepository(MarsWeatherContext context)
        {
            _context = context;
        }

        public IQueryable<Business.Models.Sol> Get()
        {
            return _context.Sols.Take(7).Cast<Business.Models.Sol>();
        } 

        public async Task<Business.Models.Sol> GetByIdAsync(Guid id)
        {
            return (Business.Models.Sol)await _context.Sols.FirstOrDefaultAsync(s => s.Id == id);
        }

        public Task<bool> CreateOrUpdate(Business.Models.Sol model)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateOrUpdate(IEnumerable<Business.Models.Sol> models)
        {
            throw new NotImplementedException();
        }
    }
}
