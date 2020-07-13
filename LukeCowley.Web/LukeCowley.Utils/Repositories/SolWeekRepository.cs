//using LukeCowley.Business.Data;
////using LukeCowley.Business.Models;
//using LukeCowley.Data.Contexts;
//using LukeCowley.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LukeCowley.Data.Repositories
//{
//    public class SolWeekRepository : IRepository<Business.Models.Sol>, IDisposable
//    {
//        private readonly MarsWeatherContext _context;
//        public SolWeekRepository(MarsWeatherContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Business.Models.Sol>> GetAsync()
//        {
//            return (await _context.Sols.Take(7).ToListAsync())
//                .Cast<Business.Models.Sol>();
//        } 

//        public async Task<Business.Models.Sol> GetByIdAsync(Guid id)
//        {
//            return (Business.Models.Sol)await _context.Sols.FirstOrDefaultAsync(s => s.Id == id);
//        }

//        public async Task<bool> CreateOrUpdateAsync(Business.Models.Sol model)
//        {
//            if (!model.IsValid()) return false;
//            var sol = (await _context.Sols.FirstOrDefaultAsync(s => s.Number == model.Number)) ??
//                new Sol
//                {
//                    Number = model.Number,
//                    CreatedOn = DateTime.Now,                   
//                };

//            sol.UpdatedOn = DateTime.Now;
//            sol.StartDate = model.StartDate;
//            sol.EndDate = model.EndDate;
//            sol.AverageWindDirection = model.WeatherProfile.WindDirection;

//        }

//        public Task<int> CreateOrUpdateAsync(IEnumerable<Business.Models.Sol> models)
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            _context.Dispose();
//        }

//        private bool AddSolToContext(Business.Models.Sol model)
//        {

//        }

//        private static bool AddMetricToSol(Sol sol, Business.Models.Metric metric)
//        {
//            var reading = sol.Readings.FirstOrDefault();
//        }
//    }
//}
