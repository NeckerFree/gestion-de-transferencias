using GestionTransferencias.Api.Tests;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.Billeteras.Queries;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Movimientos.Commands;
using GestionTransferencias.Application.Transaccion.Commands;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Tests
{
    public class TransaccionesControllerTests(ApiTestFixture fixture) : ControllerTests(fixture)
    {
        [Fact]
        public async Task PostTransaccion_ReturnsCreated_WhenSuccessful()
        {
            // Arrange
            var command = new CreateTransaccionCommand
            {
                Amount = 100,
                WalletOrigenId = 1,
                WalletDestinoId = 2
            };

            var billeteraOrigen = new BilleteraDto { Id = 1, Name = "Name 1", Balance = 200, CreatedAt = new DateTime(2025, 04, 03), DocumentId = "33333", UpdatedAt = new DateTime(2025, 04, 03) };
            var billeteraDestino = new BilleteraDto { Id = 1, Name = "Name 1", Balance = 50, CreatedAt = new DateTime(2025, 04, 03), DocumentId = "33333", UpdatedAt = new DateTime(2025, 04, 03) };

            _mediatorMock.Setup(m => m.Send(It.Is<GetBilleteraByIdQuery>(q => q.Id == 1), It.IsAny<CancellationToken>()))
                .ReturnsAsync(billeteraOrigen);

            _mediatorMock.Setup(m => m.Send(It.Is<GetBilleteraByIdQuery>(q => q.Id == 2), It.IsAny<CancellationToken>()))
                .ReturnsAsync(billeteraDestino);

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBilleteraCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateMovimientoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new MovimientoDto { Id = 1, Amount = 50, Tipo = "Crédito", WalletId = 1, CreatedAt = new DateTime(2025, 4, 3) });

            // Act
            var response = await _client.PostAsJsonAsync("/api/Transacciones", command);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PostTransaccion_ReturnsBadRequest_WhenAmountIsNegative()
        {
            // Arrange
            var command = new CreateTransaccionCommand
            {
                Amount = -100,
                WalletOrigenId = 1,
                WalletDestinoId = 2
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Transacciones", command);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostTransaccion_ReturnsNotFound_WhenWalletOrigenDoesNotExist()
        {
            // Arrange
            var command = new CreateTransaccionCommand
            {
                Amount = 100,
                WalletOrigenId = 999, // Non-existent
                WalletDestinoId = 2
            };

            _mediatorMock.Setup(m => m.Send(It.Is<GetBilleteraByIdQuery>(q => q.Id == 999), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BilleteraDto?)null);

            // Act
            var response = await _client.PostAsJsonAsync("/api/Transacciones", command);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PostTransaccion_ReturnsBadRequest_WhenBalanceIsInsufficient()
        {
            // Arrange
            var command = new CreateTransaccionCommand
            {
                Amount = 100,
                WalletOrigenId = 1,
                WalletDestinoId = 2
            };

            var billeteraOrigen = new BilleteraDto { Id = 1, Name = "Name 1", Balance = 50, CreatedAt = new DateTime(2025, 04, 03), DocumentId = "33333", UpdatedAt = new DateTime(2025, 04, 03) }; // Balance less than amount

            _mediatorMock.Setup(m => m.Send(It.Is<GetBilleteraByIdQuery>(q => q.Id == 1), It.IsAny<CancellationToken>()))
                .ReturnsAsync(billeteraOrigen);

            _mediatorMock.Setup(m => m.Send(It.Is<GetBilleteraByIdQuery>(q => q.Id == 2), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BilleteraDto { Id = 1, Name = "Name 2", Balance = 50, CreatedAt = new DateTime(2025, 04, 03), DocumentId = "55555", UpdatedAt = new DateTime(2025, 04, 03) });

            // Act
            var response = await _client.PostAsJsonAsync("/api/Transacciones", command);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}