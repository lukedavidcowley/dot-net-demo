using Hangfire;
using LukeCowley.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LukeCowley.WeatherAPI.Data
{
    public class WeatherDataRetrivalService
    {
        private readonly IMarsWeatherService _marsWeatherService;
        public WeatherDataRetrivalService(IMarsWeatherService service)
        {
            _marsWeatherService = service;
        }

        [DisableConcurrentExecution(60)]
        public async Task UpdateMarsWeather()
        {
            await _marsWeatherService.UpdateWeatherAsync();
        }

    }
}
