using FluentAssertions;
using GestionTransferencias.Application.Billeteras.Queries;
using GestionTransferencias.Application.DTOs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace GestionTransferencias.IntegrationTests
{


    public class BilleterasControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly Mock<IMediator> _mediatorMock = new();

        public BilleterasControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton(_mediatorMock.Object);
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetBilleteras_ReturnsSuccess_WithPagination()
        {
            // Arrange
            var expectedBilleteras = new List<BilleteraDto>
        {
            new() {
                Id = 1,
                DocumentId = "556676",
                Name = "Billetera 1",
                Balance = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            },
            new() {
                Id = 2,
                DocumentId = "7654",
                Name = "Billetera 2",
                Balance = 1000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }
        };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetBilleterasQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedBilleteras);

            // Act
            var response = await _client.GetAsync("/api/Billeteras?pageNumber=1&pageSize=10");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<List<BilleteraDto>>();
            result.Should().BeEquivalentTo(expectedBilleteras);
        }
    }
}
