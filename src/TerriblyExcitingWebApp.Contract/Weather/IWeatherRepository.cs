using System;
using System.Collections.Generic;

namespace TerriblyExcitingWebApp.Contract.Weather
{
    public interface IWeatherRepository
    {
        IEnumerable<WeatherForecast> Get();
    }
}
