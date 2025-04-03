using AutoMapper;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Movimientos.Commands;
using GestionTransferencias.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace GestionTransferencias.Application.Movimientos.Handlers
{
    public class CreateMovimientoCommandHandler(IHistorialMovimientoRepository MovimientoRepository, IMapper mapper) : IRequestHandler<CreateMovimientoCommand, MovimientoDto>
    {
        public async Task<MovimientoDto> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimiento = new HistorialMovimiento
            {
                Amount = request.Amount,
                Tipo = request.Tipo,
                WalletId = request.WalletId,
                CreatedAt = DateTime.Now,
            };

            await MovimientoRepository.AddAsync(movimiento);
            return mapper.Map<MovimientoDto>(movimiento);
        }
    }
}