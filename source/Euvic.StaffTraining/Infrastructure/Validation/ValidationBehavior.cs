using Euvic.StaffTraining.Common;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Euvic.StaffTraining.Infrastructure.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IEnumerable<IAsyncValidator<TRequest>> _asyncValidators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IEnumerable<IAsyncValidator<TRequest>> asyncValidators)
        {
            _validators = validators;
            _asyncValidators = asyncValidators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
               .Select(v => v.Validate(context))
               .SelectMany(vr => vr.Errors)
               .Where(vf => vf != null)
               .ToList();

            var asyncValidatorFailures = new List<ValidationFailure>();
            foreach (var validator in _asyncValidators)
            {
                var result = await validator.ValidateAsync(request);
                asyncValidatorFailures.AddRange(result.Errors);
            }

            failures.AddRange(asyncValidatorFailures);

            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}
