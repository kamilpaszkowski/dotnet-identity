using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Attendees.Queries.GetAttendeesLookup;

namespace Euvic.StaffTraining.Features.Attendees.Queries.GetAttendeesLookup
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.AttendeeSelectItem>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contract.AttendeeSelectItem>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var attendees = await _context.Attendees
                .OrderBy(x => x.Lastname)
                .ThenBy(x => x.Firstname)
                .Select(x =>
                new Contract.AttendeeSelectItem()
                {
                    Value = x.Id,
                    Label = $"{x.Firstname} {x.Lastname}"
                })
                .ToListAsync();

            return attendees;
        }
    }
}
