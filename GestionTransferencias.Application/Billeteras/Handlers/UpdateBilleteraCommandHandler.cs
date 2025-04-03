using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;

namespace GestionTransferencias.Application.Billeteras.Handlers
{
    public class UpdateBilleteraCommandHandler(IBilleteraRepository repository) : IRequestHandler<UpdateBilleteraCommand, bool>
    {
        private readonly IBilleteraRepository _repository = repository;

        public async Task<bool> Handle(UpdateBilleteraCommand request, CancellationToken cancellationToken)
        {
            var Billetera = await _repository.GetByIdAsync(request.Id);
            if (Billetera == null)
            {
                return false;
            }

            Billetera.DocumentId = request.DocumentId;
            Billetera.Name = request.Name;
            Billetera.Balance = request.Balance;
            Billetera.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(Billetera);
            return true;
        }
    }
}
