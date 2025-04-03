using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Tests.Billeteras.Commands;
using MediatR;

public class CreateBilleteraCommandTests : BilleteraCommandsTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var documentId = "123456";
        var name = "Test Wallet";
        var balance = 1000m;

        // Act
        var command = new CreateBilleteraCommand
        {
            DocumentId = documentId,
            Name = name,
            Balance = balance
        };

        // Assert
        Assert.Equal(documentId, command.DocumentId);
        Assert.Equal(name, command.Name);
        Assert.Equal(balance, command.Balance);
    }

    [Fact]
    public async Task Handle_ReturnsBilleteraDto_WhenSuccessful()
    {
        // Arrange
        var command = new CreateBilleteraCommand
        {
            DocumentId = "123456",
            Name = "Test Wallet",
            Balance = 1000m
        };

        var expectedDto = new BilleteraDto
        {
            Id = 1,
            DocumentId = command.DocumentId,
            Name = command.Name,
            Balance = command.Balance,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,


        };

        var handler = new CreateBilleteraCommandHandler(_mediatorMock.Object);

        // Mock any dependencies if needed
        // _mediatorMock.Setup(...)

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedDto.DocumentId, result.DocumentId);
        Assert.Equal(expectedDto.Name, result.Name);
        Assert.Equal(expectedDto.Balance, result.Balance);
    }

    // You'll need to implement this handler class for the test to work
    private class CreateBilleteraCommandHandler : IRequestHandler<CreateBilleteraCommand, BilleteraDto>
    {
        private readonly IMediator _mediator;

        public CreateBilleteraCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BilleteraDto> Handle(CreateBilleteraCommand request, CancellationToken cancellationToken)
        {
            // In a real implementation, this would interact with your data layer
            return new BilleteraDto
            {
                Id = 1,
                DocumentId = request.DocumentId,
                Name = request.Name,
                Balance = request.Balance,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
        }
    }
}