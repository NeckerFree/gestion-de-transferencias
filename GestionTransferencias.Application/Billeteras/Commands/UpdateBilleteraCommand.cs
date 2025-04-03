using MediatR;
using System;

namespace GestionTransferencias.Application.Billeteras.Commands
{
    public class UpdateBilleteraCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required string DocumentId { get; set; }
        public required string Name { get; set; }
        public required decimal Balance { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
