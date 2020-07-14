using LukeCowley.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeCowley.WeatherAPI.Data
{
    public class MarsWeatherContextFactory : IDesignTimeDbContextFactory<MarsWeatherContext>
    {
            // This class is used to help entity framework configure the db during migrations
            public MarsWeatherContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<MarsWeatherContext>();
                builder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MarsWeather;Integrated Security=True", b => b.MigrationsAssembly("LukeCowley.WeatherAPI")); //TODO: UserSecrets
                var context = new MarsWeatherContext(builder.Options);
                return context;
            }
        }
}
