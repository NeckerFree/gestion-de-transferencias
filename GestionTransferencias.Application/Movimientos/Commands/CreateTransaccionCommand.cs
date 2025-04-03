using GestionTransferencias.Application.DTOs;
using MediatR;
using System;

namespace GestionTransferencias.Application.Movimientos.Commands
{
    internal class CreateTransaccionCommand: IRequest<TransaccionDto>
    {
        
            public int Id { get; set; }

            public int WalletOrigenId { get; set; }

            public int WalletDestinoId { get; set; }

            public required decimal Amount { get; set; }

            public DateTime CreatedAt { get; set; }

        
    }
}
