using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TerriblyExcitingWebApp.Data;

namespace TerriblyExcitingWebApp.IntegrationTests.Factory
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<TerriblyExcitingDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TerriblyExcitingDbContext_Test");
                    options.UseInternalServiceProvider(serviceProvider);
                });
            });
        }
    }
}