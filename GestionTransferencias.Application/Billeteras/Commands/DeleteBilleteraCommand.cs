using MediatR;

namespace GestionTransferencias.Application.Billeteras.Commands
{
    public class DeleteBilleteraCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }
}
