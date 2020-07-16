using LukeCowley.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LukeCowley.WeatherAPI.Data
{
    public class MarsWeatherContextFactory : IDesignTimeDbContextFactory<MarsWeatherContext>
    {
        // This class is used to help entity framework configure the db during migrations
        public MarsWeatherContext CreateDbContext(string[] args)
        {
            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../LukeCowley.WeatherAPI"))
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<MarsWeatherContext>();
            var connectionString = config.GetConnectionString("default");
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("LukeCowley.WeatherAPI"));
            return new MarsWeatherContext(optionsBuilder.Options);
        }
    }
}

