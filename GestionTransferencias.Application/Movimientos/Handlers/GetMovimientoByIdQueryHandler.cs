using MediatR;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using GestionTransferencias.Application.Movimientos.Queries;
using System.Collections.Generic;

namespace GestionTransferencias.Application.Movimientos.Handlers
{
    public class GetMovimientoByIdQueryHandler(IHistorialMovimientoRepository MovimientoRepository, IMapper mapper) : IRequestHandler<GetMovimientoByIdQuery, MovimientoDto>
    {
        
        public async Task<MovimientoDto> Handle(GetMovimientoByIdQuery request, CancellationToken cancellationToken)
        {
            var Movimiento = await MovimientoRepository.GetByIdAsync(request.Id);
           var MovimientoDto= mapper.Map<MovimientoDto>(Movimiento);
            return MovimientoDto;
        }
    }
}

