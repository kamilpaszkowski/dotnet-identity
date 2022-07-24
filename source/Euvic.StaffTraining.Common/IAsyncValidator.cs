using System.Threading.Tasks;
using FluentValidation.Results;

namespace Euvic.StaffTraining.Common
{
    public interface IAsyncValidator<in TRequest>
    {
        public Task<ValidationResult> ValidateAsync(TRequest request);
    }
}
