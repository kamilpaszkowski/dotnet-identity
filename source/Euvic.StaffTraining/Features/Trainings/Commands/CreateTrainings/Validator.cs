
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.CreateTraining;

namespace Euvic.StaffTraining.Features.Trainings.Commands.CreateTrainings
{
    internal class Validator : AbstractAsyncValidator<Contract.Command>
    {
        private readonly StaffTrainingContext _context;

        public Validator(StaffTrainingContext context)
        {
            _context = context;
        }

        public override async Task<ValidationResult> ValidateAsync(Contract.Command request)
        {
            var trainingAlreadyExists = await _context.Trainings.AnyAsync(x => x.Title == request.Title && x.LecturerId == request.LecturerId);
            if (trainingAlreadyExists)
                AddError(nameof(request.Title), "Szkolenie o takim tytule już zostało dodane");

            return ValidationResult;
        }
    }
}
