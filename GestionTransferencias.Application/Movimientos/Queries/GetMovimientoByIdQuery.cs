using GestionTransferencias.Application.DTOs;
using MediatR;

namespace GestionTransferencias.Application.Movimientos.Queries
{
    public class GetMovimientoByIdQuery : IRequest<MovimientoDto>
    {
        public int Id { get; set; }
    }
}
