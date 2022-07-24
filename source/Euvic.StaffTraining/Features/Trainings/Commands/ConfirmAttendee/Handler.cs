using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.ConfirmAttendee;

namespace Euvic.StaffTraining.Features.Trainings.Commands.ConfirmAttendee
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
                 .Include(x => x.Attendees.Where(a => a.AttendeeId == request.AttendeeId)) // TOO EXPLAIN
                    .ThenInclude(x => x.Attendee)
                 .FirstOrDefaultAsync(x => x.Id == request.TrainingId);

            var trainingAttendee = training.Attendees.FirstOrDefault(x => x.AttendeeId == request.AttendeeId);

            trainingAttendee.StatusId = (int)TrainingAttendeeStatuses.Confirmed;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
