using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Euvic.StaffTraining.Common
{
    public abstract class AbstractAsyncValidator<TRequest> : IAsyncValidator<TRequest>
    {
        protected ValidationResult ValidationResult { get; } = new ValidationResult();
        public abstract Task<ValidationResult> ValidateAsync(TRequest request);

        protected void AddError(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        protected void ThrowValidationException(string message) => throw new ValidationException(message);
    }
}
