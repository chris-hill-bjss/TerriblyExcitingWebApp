using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TerriblyExcitingWebApp.Contract.Weather;

namespace TerriblyExcitingWebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(DateTime startDate)
        {
            var forecast = _weatherService.Get(startDate);

            return Ok(forecast);
        }
    }
}
