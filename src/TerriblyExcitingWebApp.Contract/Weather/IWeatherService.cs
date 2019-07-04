using System;
using System.Collections.Generic;

namespace TerriblyExcitingWebApp.Contract.Weather
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> Get(DateTime startDate);
    }
}
