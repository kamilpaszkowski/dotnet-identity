using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.DeclineAttendee;

namespace Euvic.StaffTraining.Features.Trainings.Commands.DeclineAttendee
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

            var trainingAttendee = training.Attendees.FirstOrDefault(x => x.AttendeeId == request.AttendeeId);
            training.Attendees.Remove(trainingAttendee);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
