using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using TerriblyExcitingWebApp.Api;
using TerriblyExcitingWebApp.Contract.Weather;
using TerriblyExcitingWebApp.Data;
using TerriblyExcitingWebApp.IntegrationTests.Factory;
using Xunit;

namespace TerriblyExcitingWebApp.IntegrationTests
{
    [Binding]
    public class WeatherSteps : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        private readonly IWebHost _webHost;

        private WeatherForecast[] _forecasts;

        public WeatherSteps(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
            _webHost = _factory.Server?.Host;
        }

        [Given(@"the following forecast data")]
        public async Task GivenTheFollowingForecastData(Table table)
        {
            using (var scope = _webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TerriblyExcitingDbContext>();

                context.Forecasts.AddRange(
                    table.Rows.Select(row =>
                        new Data.Models.Forecast
                        {
                            Date = DateTime.Parse(row[0]),
                            TemperatureC = Convert.ToDouble(row[1])
                        }));

                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I get data from the weather api with the date ""(.*)""")]
        public async Task WhenIGetDataFromTheWeatherApiWithTheDate(string date)
        {
            _forecasts = await _client.GetJsonAsync<WeatherForecast[]>($"api/weather?startDate={date}");
            _forecasts.Should().NotBeEmpty();
        }
        
        [Then(@"I should get the following response")]
        public void ThenIShouldGetTheFollowingResponse(Table table)
        {
            _forecasts.Should().BeEquivalentTo(
                table.Rows.Select(row =>
                    new WeatherForecast
                    {
                        Date = DateTime.Parse(row[0]),
                        TemperatureC = Convert.ToDouble(row[1])
                    }));
        }
    }
}