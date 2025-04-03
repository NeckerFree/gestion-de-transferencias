using AutoMapper;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Billeteras.Queries;
using GestionTransferencias.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestionTransferencias.Application.Billeteras.Handlers
{

    public class GetBilleterasQueryHandler(IBilleteraRepository repository, IMapper mapper) : IRequestHandler<GetBilleterasQuery, IEnumerable<BilleteraDto>>
    {
        public async Task<IEnumerable<BilleteraDto>> Handle(GetBilleterasQuery request, CancellationToken cancellationToken)
        {
            var Billeteras = await repository.GetAllAsync();
        return mapper.Map<List<BilleteraDto>>(Billeteras);
        }
    }
}
