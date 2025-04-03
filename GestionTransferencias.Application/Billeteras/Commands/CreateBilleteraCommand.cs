using GestionTransferencias.Application.DTOs;
using MediatR;
using System;

namespace GestionTransferencias.Application.Billeteras.Commands
{
    public class CreateBilleteraCommand : IRequest<BilleteraDto>
    {
        public int Id { get; set; }

        public required string DocumentId { get; set; }

        public required string Name { get; set; }

        public required decimal Balance { get; set; }

    }
   
}
