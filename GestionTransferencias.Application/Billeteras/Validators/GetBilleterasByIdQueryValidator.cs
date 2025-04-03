using FluentValidation;
using GestionTransferencias.Application.Billeteras.Queries;

namespace GestionTransferencias.Application.Billeteras.Validators
{
    public class GetBilleteraByIdQueryValidator: AbstractValidator<GetBilleteraByIdQuery>
    {
        public GetBilleteraByIdQueryValidator() {
            RuleFor(x=> x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
