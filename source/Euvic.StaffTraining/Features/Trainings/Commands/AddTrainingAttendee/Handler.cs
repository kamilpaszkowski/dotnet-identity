using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Features.Attendees.Exceptions;
using Euvic.StaffTraining.Features.Trainings.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.AddTrainingAttendee;

namespace Euvic.StaffTraining.Features.Trainings.Commands.AddTrainingAttendee
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
            var training = await _context.Trainings.Include(x => x.Attendees).FirstOrDefaultAsync(x => x.Id == request.TrainingId);
            var attendee = await _context.Attendees.FirstOrDefaultAsync(x => x.Id == request.AttendeeId);

            if (training == null)
                throw new TrainingNotFoundException(request.TrainingId, "Training not found", $"Training with id {request.TrainingId} not found");

            if (attendee == null)
                throw new AttendeeNotFoundException(request.AttendeeId, "Attendee not found", $"Attendee with Id {request.AttendeeId} not found");

            if (!training.Attendees.Any(x => x.AttendeeId == request.AttendeeId))
            {
                training.Attendees.Add(new TrainingAttendee()
                {
                    AttendeeId = request.AttendeeId,
                    StatusId = (int)TrainingAttendeeStatuses.Interested,
                });
            }

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
