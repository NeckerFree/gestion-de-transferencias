using GestionTransferencias.Application.DTOs;
using MediatR;

namespace GestionTransferencias.Application.Transaccion.Commands
{
    public class CreateTransaccionCommand : IRequest<TransaccionDto>
    {
        public int Id { get; set; }

        public int WalletOrigenId { get; set; }

        public int WalletDestinoId { get; set; }

        public required decimal Amount { get; set; }

    }
}
