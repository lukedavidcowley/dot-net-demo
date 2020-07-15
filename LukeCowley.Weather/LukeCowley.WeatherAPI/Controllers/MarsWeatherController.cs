using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LukeCowley.Business.Models;
using LukeCowley.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LukeCowley.WeatherAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 12 * 60 * 60)]
    public class MarsWeatherController : ControllerBase
    {
        private readonly IMarsWeatherService _marsWeatherService; 
        public MarsWeatherController(IMarsWeatherService marsService)
        {
            _marsWeatherService = marsService;
        }

        [HttpGet("LastWeek")]
        public async Task<IEnumerable<Sol>> GetSolWeek()
        {
            return await _marsWeatherService.GetSolWeekAsync();
        }

    }
}