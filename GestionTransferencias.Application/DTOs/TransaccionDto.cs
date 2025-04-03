using System;

namespace GestionTransferencias.Application.DTOs
{
    public  class TransaccionDto
    {
        public int Id { get; set; }

        public int WalletOrigenId { get; set; }

        public int WalletDestinoId { get; set; }

        public required decimal Amount { get; set; }

    }
}
