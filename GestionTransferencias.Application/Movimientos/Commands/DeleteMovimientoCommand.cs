using MediatR;

namespace GestionTransferencias.Application.Movimientos.Commands
{
    public class DeleteMovimientoCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}
