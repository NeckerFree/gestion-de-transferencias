using AutoMapper;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Movimientos.Queries;
using GestionTransferencias.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestionTransferencias.Application.Movimientos.Handlers
{

    public class GetMovimientosQueryHandler(IHistorialMovimientoRepository repository, IMapper mapper) : IRequestHandler<GetMovimientosQuery, IEnumerable<MovimientoDto>>
    {
        public async Task<IEnumerable<MovimientoDto>> Handle(GetMovimientosQuery request, CancellationToken cancellationToken)
        {
            var Movimientos = await repository.GetAllAsync();
        return mapper.Map<List<MovimientoDto>>(Movimientos);
        }
    }
}
