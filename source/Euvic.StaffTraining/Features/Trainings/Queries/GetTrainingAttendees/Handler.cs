using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Queries.GetTrainingAttendees;

namespace Euvic.StaffTraining.Features.Trainings.Queries.GetTrainingAttendees
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.Attendee>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contract.Attendee>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var attendees = await _context.Trainings
                .Include(x => x.Attendees)
                    .ThenInclude(x => x.Attendee)
                .Include(x => x.Attendees)
                    .ThenInclude(x => x.Status)
                .Where(x => x.Id == request.TrainingId)
                .SelectMany(x => x.Attendees)
                .Where(x => !request.StatusId.HasValue || x.StatusId == request.StatusId)
                .Select(x => new Contract.Attendee()
                {
                    Id = x.Attendee.Id,
                    Firstname = x.Attendee.Firstname,
                    Lastname = x.Attendee.Lastname,
                    Status = x.Status.Name,
                    StatusId = x.StatusId
                })
                .ToListAsync();

            return attendees;
        }
    }
}
