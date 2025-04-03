using GestionTransferencias.Domain.Entities;
using MediatR;

namespace GestionTransferencias.Application.Movimientos.Commands
{
    public class GetMovimientoCommand : IRequest<HistorialMovimiento>
    {
        public int Id { get; set; }
    }
}
