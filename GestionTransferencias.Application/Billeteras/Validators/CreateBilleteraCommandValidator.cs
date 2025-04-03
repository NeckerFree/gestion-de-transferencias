using FluentValidation;
using GestionTransferencias.Application.Billeteras.Commands;

namespace GestionTransferencias.Application.Billeteras.Validators
{
    public class CreateBilleteraCommandValidator : AbstractValidator<CreateBilleteraCommand>
    {
        public CreateBilleteraCommandValidator()
        {
            //// Rule for Id (must be positive)
            //RuleFor(x => x.Id)
            //    .GreaterThan(0).WithMessage("Id must be greater than 0.");

            // Rule for DocumentId (required, max length 20)
            RuleFor(x => x.DocumentId)
                .NotEmpty().WithMessage("El DocumentId es requerido.")
                .MaximumLength(30).WithMessage("El DocumentId no puede exceder 30 caracteres.");

            // Rule for Name (required, max length 100)
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Nombre es requerido.")
                .MaximumLength(30).WithMessage("El Nombre no puede exceder 30 caracteres.");

            // Rule for Balance (must be non-negative)
            RuleFor(x => x.Balance)
                .GreaterThan(0).WithMessage("El Balance debe ser mayor que cero");
        }
    }
}