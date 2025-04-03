using GestionTransferencias.Api.Tests;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.Billeteras.Queries;
using GestionTransferencias.Application.DTOs;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Tests
{
    public class BilleterasControllerTests(ApiTestFixture fixture) : ControllerTests(fixture)
    {
        [Fact]
        public async Task GetBilleteras_ReturnsOkWithPagedResults()
        {
            // Arrange
            var expectedBilleteras = new List<BilleteraDto>
        {
            new() { Id = 1, Name = "Test 1", Balance = 100, CreatedAt= new DateTime(2025, 04,03), DocumentId="33333", UpdatedAt = new DateTime(2025, 04,03)},
            new() { Id = 2, Name = "Test 2", Balance = 100, CreatedAt= new DateTime(2025, 04,03), DocumentId="44444", UpdatedAt = new DateTime(2025, 04,03)},
        };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBilleterasQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedBilleteras);

            // Act
            var response = await _client.GetAsync("/api/Billeteras?pageNumber=1&pageSize=10");

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<List<BilleteraDto>>();
            Assert.Equal(2, result?.Count);
        }

        [Fact]
        public async Task GetBilletera_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBilleteraByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BilleteraDto?)null);

            // Act
            var response = await _client.GetAsync("/api/Billeteras/999");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PostBilletera_ReturnsCreatedAtAction_WithValidData()
        {
            // Arrange
            var newBilletera = new CreateBilleteraCommand { Name = "New", DocumentId = "123", Balance = 100 };
            var expectedResult = new BilleteraDto { Id = 1, Name = "New", DocumentId = "123", Balance = 100, CreatedAt = new DateTime(2025, 04, 03), UpdatedAt = new DateTime(2025, 04, 03) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResult);

            // Act
            var response = await _client.PostAsJsonAsync("/api/Billeteras", newBilletera);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var content = await response.Content.ReadFromJsonAsync<BilleteraDto>();
            Assert.Equal(expectedResult.Id, content?.Id);
        }

        [Fact]
        public async Task PutBilletera_ReturnsNoContent_WhenUpdateSucceeds()
        {
            // Arrange
            var updateCommand = new UpdateBilleteraCommand { Id = 1, Name = "Updated", DocumentId = "123", Balance = 150, UpdatedAt = new DateTime(2025, 04, 03) };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var response = await _client.PutAsJsonAsync("/api/Billeteras/1", updateCommand);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteBilletera_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            // Act
            var response = await _client.DeleteAsync("/api/Billeteras/999");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}