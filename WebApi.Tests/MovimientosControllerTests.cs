using GestionTransferencias.Api.Tests;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Movimientos.Commands;
using GestionTransferencias.Application.Movimientos.Queries;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Tests
{
    public class MovimientosControllerTests(ApiTestFixture fixture) : ControllerTests(fixture)
    {
        [Fact]
        public async Task GetMovimientos_ReturnsOkWithPagedResults()
        {
            // Arrange
            var expectedMovimientos = new List<MovimientoDto>
        {
            new() { Id = 1, Amount = 100, Tipo = "Crédito", WalletId = 1 },
            new() { Id = 2, Amount = 200, Tipo = "Débito", WalletId = 2 }
        };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetMovimientosQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedMovimientos);

            // Act
            var response = await _client.GetAsync("/api/Movimientos?pageNumber=1&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<List<MovimientoDto>>();
            Assert.Equal(2, result?.Count);
        }

        [Fact]
        public async Task PostMovimiento_ReturnsCreatedAtAction_WithValidData()
        {
            // Arrange
            var newMovimiento = new CreateMovimientoCommand
            {
                Amount = 100,
                Tipo = "Crédito",
                WalletId = 1,
                CreatedAt = DateTime.Now
            };

            var expectedResult = new MovimientoDto
            {
                Id = 1,
                Amount = 100,
                Tipo = "Crédito",
                WalletId = 1,
                CreatedAt = DateTime.Now
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateMovimientoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            // Act
            var response = await _client.PostAsJsonAsync("/api/Movimientos", newMovimiento);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var content = await response.Content.ReadFromJsonAsync<MovimientoDto>();
            Assert.Equal(expectedResult.Id, content?.Id);
        }
    }
}