using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
namespace GestionTransferencias.IntegrationTests
{


    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Mock dependencies if needed (e.g., replace real database with in-memory)
                services.AddScoped<IMediator>(_ => Mock.Of<IMediator>());
            });

            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders(); // Disable external logging
            });
        }
    }
}
