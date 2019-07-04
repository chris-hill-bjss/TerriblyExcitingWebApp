using System;
using System.Collections.Generic;
using System.Linq;
using TerriblyExcitingWebApp.Contract.Weather;

namespace TerriblyExcitingWebApp.Data.Weather
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly TerriblyExcitingDbContext _dbContext;

        public WeatherRepository(TerriblyExcitingDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<WeatherForecast> Get() =>
            _dbContext.Forecasts
                .ToList()
                .Select(forecast => new WeatherForecast
                {
                    Date = forecast.Date,
                    TemperatureC = forecast.TemperatureC
                });
    }
}