using AutoMapper;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace GestionTransferencias.Application.Billeteras.Handlers
{
    public class CreateBilleteraCommandHandler(IBilleteraRepository BilleteraRepository, IMapper mapper) : IRequestHandler<CreateBilleteraCommand, BilleteraDto>
    {
        public async Task<BilleteraDto> Handle(CreateBilleteraCommand request, CancellationToken cancellationToken)
        {
            var Billetera = new Billetera
            {
                DocumentId = request.DocumentId,
                Name = request.Name,
                Balance = request.Balance,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            await BilleteraRepository.AddAsync(Billetera);
            return mapper.Map<BilleteraDto>(Billetera);
        }
    }
}