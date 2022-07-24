using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Features.Attendees.Exceptions;
using Euvic.StaffTraining.Features.Trainings.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.UnconfirmAttendee;

namespace Euvic.StaffTraining.Features.Trainings.Commands.UnconfirmAttendee
{
    internal class Handler : ICommandHandler<Contract.Command>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var training = await _context.Trainings
                 .Include(x => x.Attendees)
                 .ThenInclude(x => x.Attendee)
                 .FirstOrDefaultAsync(x => x.Id == request.TrainingId);

            if (training == null)
                throw new TrainingNotFoundException(request.TrainingId, "Training not found", $"Training with id {request.TrainingId} not found");

            var trainingAttendee = training.Attendees.FirstOrDefault(x => x.AttendeeId == request.AttendeeId);
            if (trainingAttendee == null)
                throw new AttendeeNotFoundException(request.AttendeeId, "Attendee not found", $"Attendee with Id {request.AttendeeId} not found");

            trainingAttendee.StatusId = (int)TrainingAttendeeStatuses.Interested;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
