using GestionTransferencias.Domain.Entities;
using MediatR;

namespace GestionTransferencias.Application.Products.Commands
{
    public class GetBilleteraCommand : IRequest<Billetera>
    {
        public int Id { get; set; }
    }
}
