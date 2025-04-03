using Moq;
using IMediator = MediatR.IMediator;

namespace GestionTransferencias.Application.Tests.Billeteras.Commands
{
    public class BilleteraCommandsTests
    {
        protected readonly Mock<IMediator> _mediatorMock = new();
    }
}