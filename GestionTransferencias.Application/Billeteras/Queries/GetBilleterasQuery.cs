using GestionTransferencias.Application.DTOs;
using MediatR;
using System.Collections.Generic;
namespace GestionTransferencias.Application.Billeteras.Queries
{
    public class GetBilleterasQuery : IRequest<IEnumerable<BilleteraDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
