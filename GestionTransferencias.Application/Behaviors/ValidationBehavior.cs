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
//using FluentValidation;
//using MediatR;

//namespace GestionTransferencias.Application.Behaviors
//{
//    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : IRequest<TResponse>
//    {
//        private readonly IEnumerable<IValidator<TRequest>> _validators;

//        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//        {
//            _validators = validators;
//        }

//        public async Task<TResponse> Handle(
//            TRequest request,
//            RequestHandlerDelegate<TResponse> next,
//            CancellationToken cancellationToken)
//        {
//            // Skip validation if no validators are registered
//            if (!_validators.Any())
//                return await next();

//            // Run validation
//            var context = new ValidationContext<TRequest>(request);
//            var validationResults = await Task.WhenAll(
//                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
//            );
//            var failures = validationResults
//                .SelectMany(r => r.Errors)
//                .Where(f => f != null)
//                .ToList();

//            if (failures.Any())
//                throw new ValidationException(failures);

//            return await next();
//        }
//    }
//}