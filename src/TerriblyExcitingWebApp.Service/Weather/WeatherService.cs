using System;
using System.Collections.Generic;
using System.Linq;
using TerriblyExcitingWebApp.Contract.Weather;

namespace TerriblyExcitingWebApp.Service.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _repository;

        public WeatherService(IWeatherRepository repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public IEnumerable<WeatherForecast> Get(DateTime startDate) =>
            _repository
                .Get()
                .Where(forecast => forecast.Date >= startDate && forecast.Date <= startDate.AddDays(6));
    }
}
