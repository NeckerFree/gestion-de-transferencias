
using FluentValidation;
using GestionTransferencias.Application.Transaccion.Commands;


namespace GestionTransferencias.Application.Transaccion.Validators
{
    public class CreateTransaccionCommandValidator : AbstractValidator<CreateTransaccionCommand>
    {
        public CreateTransaccionCommandValidator()
        {

            // Regla para WalletOrigenId (debe ser positivo y diferente a WalletDestinoId)
            RuleFor(x => x.WalletOrigenId)
                .GreaterThan(0).WithMessage("El ID de la billetera de origen debe ser válido.")
                .NotEqual(x => x.WalletDestinoId)
                .WithMessage("La billetera de origen y destino no pueden ser iguales.");

            // Regla para WalletDestinoId (debe ser positivo)
            RuleFor(x => x.WalletDestinoId)
                .GreaterThan(0).WithMessage("El ID de la billetera destino debe ser válido.");

            // Regla para WalletDestinoId (debe ser positivo)
            RuleFor(x => x.WalletDestinoId)
                .GreaterThan(0).WithMessage("El ID de la billetera de destino debe ser válido.");

            // Regla para Amount (debe ser positivo y mayor que 0)
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto debe ser mayor que 0.")
                .LessThan(1000000).WithMessage("El monto no puede exceder 1,000,000.");
        }
    }
}
