using GestionTransferencias.Application.DTOs;
using MediatR;
using System.Collections.Generic;
namespace GestionTransferencias.Application.Movimientos.Queries
{
    public class GetMovimientosQuery : IRequest<IEnumerable<MovimientoDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
