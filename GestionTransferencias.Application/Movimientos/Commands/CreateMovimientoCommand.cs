using GestionTransferencias.Application.DTOs;
using MediatR;
using System;

namespace GestionTransferencias.Application.Movimientos.Commands
{
    public class CreateMovimientoCommand : IRequest<MovimientoDto>
    {
        public int Id { get; set; }

        public int WalletId { get; set; }

        public required decimal Amount { get; set; }

        public required string Tipo { get; set; }

        public DateTime CreatedAt { get; set; }

    }
   
}
