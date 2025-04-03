using FluentValidation;
using GestionTransferencias.Application.Movimientos.Queries;

namespace GestionTransferencias.Application.Movimientos.Validators
{
    public class GetMovimientoByIdQueryValidator: AbstractValidator<GetMovimientoByIdQuery>
    {
        public GetMovimientoByIdQueryValidator() {
            RuleFor(x=> x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
