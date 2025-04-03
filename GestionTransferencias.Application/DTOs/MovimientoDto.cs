using GestionTransferencias.Domain.Entities;
using System;

namespace GestionTransferencias.Application.DTOs
{
    public class MovimientoDto
    {
        public int Id { get; set; }

        public int WalletId { get; set; }

        public required decimal Amount { get; set; }

        public required string Tipo { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
