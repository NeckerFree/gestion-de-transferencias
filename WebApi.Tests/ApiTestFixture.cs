using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace GestionTransferencias.Api.Tests
{
    public class ApiTestFixture : WebApplicationFactory<Program>, IAsyncLifetime
    {
        public Mock<IMediator> MediatorMock { get; } = new();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Replace the real Mediator with our mock
                services.AddSingleton(MediatorMock.Object);

                // Add any other test-specific services here
            });

            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            });
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public new Task DisposeAsync() => Task.CompletedTask;
    }

    public class ControllerTests : IClassFixture<ApiTestFixture>
    {
        public readonly ApiTestFixture _fixture;
        public  readonly HttpClient _client;
        public readonly Mock<IMediator> _mediatorMock;

        public ControllerTests(ApiTestFixture fixture)
        {
            _fixture = fixture;
            _client = fixture.CreateClient();
            _mediatorMock = fixture.MediatorMock;
        }
    }
}