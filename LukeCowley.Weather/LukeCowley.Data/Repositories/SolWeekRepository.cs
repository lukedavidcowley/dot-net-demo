
using LukeCowley.Business.Data;
using LukeCowley.Business.Models;
using LukeCowley.Data.Contexts;
using LukeCowley.Data.Entities;
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

        public async Task<IEnumerable<Business.Models.Sol>> GetAsync()
        {
            var hardTest = _context.Sols.ToList();
            var test = _context.Sols
                .Include(s => s.Readings)
                .Cast<Business.Models.Sol>()
                .Take(7);
            return test;
        }

        public async Task<Business.Models.Sol> GetByIdAsync(Guid id)
        {
            return (Business.Models.Sol)await _context.Sols.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> CreateOrUpdateAsync(Business.Models.Sol model)
        {
            
            AddSolToContext(model);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<int> CreateOrUpdateAsync(IEnumerable<Business.Models.Sol> models)
        {
            try
            {
                foreach (var model in models)
                {
                    AddSolToContext(model);
                }
                return await _context.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }           
        }

        private void AddSolToContext(Business.Models.Sol model)
        {
            if (!model.IsValid()) return;
            var sol = _context.Sols.FirstOrDefault(s => s.Number == model.Number) ??
                new Entities.Sol
                {
                    Number = model.Number,
                    CreatedOn = DateTime.Now,
                    Readings = new List<SensorReading>()
                };
            if (sol == null) sol = new Entities.Sol
            {
                Number = model.Number,
                CreatedOn = DateTime.Now,
            };
            sol.UpdatedOn = DateTime.Now;
            sol.StartDate = model.StartDate;
            sol.EndDate = model.EndDate;
            sol.AverageWindDirection = model.WeatherProfile.WindDirection;
            AddMetricToSol(sol, model.WeatherProfile.Pressure, MetricKeys.Pressure.ToKeyString());
            AddMetricToSol(sol, model.WeatherProfile.Temperature, MetricKeys.Temperature.ToKeyString());
            AddMetricToSol(sol, model.WeatherProfile.WindSpeed, MetricKeys.WindSpeed.ToKeyString());

            if (sol.Id != default) _context.Update(sol);
            else _context.Add(sol);
        }

        private static bool AddMetricToSol(Entities.Sol sol, Metric metric, string key)
        {
            if (!metric.IsValid()) return false;
            var count = sol.Readings.Count;
            sol.Readings.Add(new SensorReading
            {
                Key = key,
                CreatedOn = DateTime.Now,
                Average = metric.Average,
                DataPointCount = metric.DataPointCount,
                Sol = sol,
                Maximum = metric.Maximum,
                Minimum = metric.Minimum,
                UpdatedOn = DateTime.Now
            });
            return ++count == sol.Readings.Count;
        }
    }
}
