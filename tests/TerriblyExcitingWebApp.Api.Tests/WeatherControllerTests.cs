using System;
using Moq;
using TerriblyExcitingWebApp.Api.Controllers;
using TerriblyExcitingWebApp.Contract.Weather;
using Xunit;

namespace TerriblyExcitingWebApp.Api.Tests
{
    public class WeatherControllerTests
    {
        [Fact]
        public void Constructing_ServiceIsNull_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new WeatherController(null));

        [Fact]
        public void OnGet_CallsService()
        {
            var mockService = new Mock<IWeatherService>();

            new WeatherController(mockService.Object).Get(DateTime.Today);

            mockService
                .Verify(
                    service => service.Get(DateTime.Today),
                    Times.Once);
        }
    }
}
