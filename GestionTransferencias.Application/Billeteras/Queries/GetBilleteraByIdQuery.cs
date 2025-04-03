using GestionTransferencias.Application.DTOs;
using MediatR;

namespace GestionTransferencias.Application.Billeteras.Queries
{
    public class GetBilleteraByIdQuery : IRequest<BilleteraDto>
    {
        public int Id { get; set; }
    }
}
