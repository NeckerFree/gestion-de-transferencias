using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionTransferencias.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var failures = validators
                 .Select(v => v.Validate(request))
                 .SelectMany(r => r.Errors)
                 .Where(v => v != null)
                 .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
