using System;
using FluentAssertions;
using Moq;
using TerriblyExcitingWebApp.Contract.Weather;
using TerriblyExcitingWebApp.Service.Weather;
using Xunit;

namespace TerriblyExcitingWebApp.Service.Tests
{
    public class WeatherServiceTests
    {
        [Fact]
        public void Constructing_RepositoryIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new WeatherService(null));

        [Fact]
        public void Get_ReturnsExpected()
        {
            DateTime startDate = DateTime.Today;

            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo
                .Setup(repo => repo.Get())
                .Returns(new[]
                {
                    new WeatherForecast { Date = startDate.AddDays(-6), TemperatureC = 12 },
                    new WeatherForecast { Date = startDate.AddDays(-5), TemperatureC = 7 },
                    new WeatherForecast { Date = startDate.AddDays(-4), TemperatureC = 6 },
                    new WeatherForecast { Date = startDate.AddDays(-3), TemperatureC = 4 },
                    new WeatherForecast { Date = startDate.AddDays(-2), TemperatureC = 0 },
                    new WeatherForecast { Date = startDate.AddDays(-1), TemperatureC = 0 },
                    new WeatherForecast { Date = startDate, TemperatureC = 1 },
                    new WeatherForecast { Date = startDate.AddDays(1), TemperatureC = 12 },
                    new WeatherForecast { Date = startDate.AddDays(2), TemperatureC = 13 },
                    new WeatherForecast { Date = startDate.AddDays(3), TemperatureC = 13 },
                    new WeatherForecast { Date = startDate.AddDays(4), TemperatureC = 15 },
                    new WeatherForecast { Date = startDate.AddDays(5), TemperatureC = 0 },
                    new WeatherForecast { Date = startDate.AddDays(6), TemperatureC = -10 },
                    new WeatherForecast { Date = startDate.AddDays(7), TemperatureC = -9 },
                    new WeatherForecast { Date = startDate.AddDays(8), TemperatureC = 3 },
                    new WeatherForecast { Date = startDate.AddDays(9), TemperatureC = 3 },
                    new WeatherForecast { Date = startDate.AddDays(10), TemperatureC = 5 },
                    new WeatherForecast { Date = startDate.AddDays(11), TemperatureC = 0 },
                    new WeatherForecast { Date = startDate.AddDays(12), TemperatureC = -1 }
                });

            new WeatherService(mockRepo.Object)
                .Get(startDate)
                .Should()
                .BeEquivalentTo(new[]
                {
                    new WeatherForecast { Date = startDate, TemperatureC = 1 },
                    new WeatherForecast { Date = startDate.AddDays(1), TemperatureC = 12 },
                    new WeatherForecast { Date = startDate.AddDays(2), TemperatureC = 13 },
                    new WeatherForecast { Date = startDate.AddDays(3), TemperatureC = 13 },
                    new WeatherForecast { Date = startDate.AddDays(4), TemperatureC = 15 },
                    new WeatherForecast { Date = startDate.AddDays(5), TemperatureC = 0 },
                    new WeatherForecast { Date = startDate.AddDays(6), TemperatureC = -10 },
                });
        }
    }
}
