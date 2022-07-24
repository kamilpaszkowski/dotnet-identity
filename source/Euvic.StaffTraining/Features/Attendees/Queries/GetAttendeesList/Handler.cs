using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Attendees.Queries.GetAttendeesList;

namespace Euvic.StaffTraining.Features.Attendees.Queries.GetAttendees
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.AttendeesListItem>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contract.AttendeesListItem>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var attendees = await _context.Attendees
              .Include(x => x.Trainings)
                  .ThenInclude(x => x.Training)
              .Select(x =>
              new Contract.AttendeesListItem()
              {
                  Id = x.Id,
                  AllowedHours = x.AllowedHours,
                  Firstname = x.Firstname,
                  Lastname = x.Lastname,
                  TotalHours = (double)x.Trainings.Sum(t => t.Training.Duration) / 60,
                  TotalConfirmedHours = (double)x.Trainings
                      .Where(x => x.StatusId == (int)TrainingAttendeeStatuses.Confirmed)
                      .Sum(t => t.Training.Duration) / 60,
              })
              .OrderBy(x => x.Lastname)
              .ThenBy(x => x.Firstname)
              .ToListAsync();

            return attendees;
        }
    }
}
