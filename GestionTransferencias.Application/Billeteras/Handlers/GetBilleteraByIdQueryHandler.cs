using MediatR;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using GestionTransferencias.Application.Billeteras.Queries;
using System.Collections.Generic;

namespace GestionTransferencias.Application.Billeteras.Handlers
{
    public class GetBilleteraByIdQueryHandler(IBilleteraRepository BilleteraRepository, IMapper mapper) : IRequestHandler<GetBilleteraByIdQuery, BilleteraDto>
    {
        
        public async Task<BilleteraDto> Handle(GetBilleteraByIdQuery request, CancellationToken cancellationToken)
        {
            var Billetera = await BilleteraRepository.GetByIdAsync(request.Id);
           var BilleteraDto= mapper.Map<BilleteraDto>(Billetera);
            return BilleteraDto;
        }
    }
}

