using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Features.Attendees.Exceptions;
using Euvic.StaffTraining.Features.Trainings.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.ConfirmAttendee;

namespace Euvic.StaffTraining.Features.Trainings.Commands.ConfirmAttendee
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
            var trainingExists = await _context.Trainings.AnyAsync(x => x.Id == request.TrainingId);
            if (!trainingExists)
                throw new TrainingNotFoundException(request.TrainingId, "Szkolenie nie istnieje", $"Training with id {request.TrainingId} not found");

            var attendeeExists = await _context.Attendees.AnyAsync(x => x.Id == request.AttendeeId);
            if (!attendeeExists)
                throw new AttendeeNotFoundException(request.AttendeeId, "Uczestnik nie istnieje", $"Attendee with Id {request.AttendeeId} not found");

            var totalConfirmedMinutes = _context.Attendees
                 .Include(x => x.Trainings)
                     .ThenInclude(x => x.Training)
                 .SelectMany(x => x.Trainings)
                 .Where(x => x.AttendeeId == request.AttendeeId && x.StatusId == (int)TrainingAttendeeStatuses.Confirmed)
                 .Sum(x => x.Training.Duration);

            var trainingDurationInMinutes = await _context.Trainings
                .Where(x => x.Id == request.TrainingId)
                .Select(x => x.Duration)
                .FirstOrDefaultAsync();

            var allowedHours = await _context.Attendees
                .Where(x => x.Id == request.AttendeeId)
                .Select(x => x.AllowedHours)
                .FirstOrDefaultAsync();

            var totalConfirmedHours = new TimeSpan(0, totalConfirmedMinutes, 0).TotalHours;
            var trainingDurationInHours = new TimeSpan(0, trainingDurationInMinutes, 0).TotalHours;

            if (totalConfirmedHours + trainingDurationInHours > allowedHours)
                ThrowValidationException("Nie możesz potwierdzić tego szkolenia ponieważ przekracza ono sume dozwolonych godzin");

            return ValidationResult;
        }
    }
}
