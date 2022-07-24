
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Features.Attendees.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Attendees.Commands.DeleteAttendee;

namespace Euvic.StaffTraining.Features.Attendees.Commands.DeleteAttendee
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
            var attendee = await _context.Attendees.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (attendee == null)
                throw new AttendeeNotFoundException(request.Id, "Attendee not found", $"Attendee with Id {request.Id} not found");

            attendee.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
