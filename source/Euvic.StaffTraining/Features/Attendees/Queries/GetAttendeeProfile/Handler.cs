using System.Security.Principal;
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Attendees.Queries.GetAttendeeProfile;

namespace Euvic.StaffTraining.Features.Attendees.Queries.GetAttendeeProfile
{
    internal class Handler : IQueryHandler<Contract.Query, Contract.AttendeeProfile>
    {
        private readonly StaffTrainingContext _context;
        private readonly IPrincipal _principal;

        public Handler(StaffTrainingContext context, IPrincipal principal)
        {
            _context = context;
            _principal = principal;
        }

        public async Task<Contract.AttendeeProfile> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var profile = await _context.Attendees
                .Include(x => x.Trainings)
                    .ThenInclude(x => x.Training)
                .Where(x => x.Id == _principal.GetAttendeeId())
                .Select(x =>
                new Contract.AttendeeProfile()
                {
                    Id = x.Id,
                    AllowedHours = x.AllowedHours,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    TotalHours = (double)x.Trainings.Sum(t => t.Training.Duration) / 60,
                    TotalConfirmedHours = (double)x.Trainings.Where(x => x.StatusId == (int)TrainingAttendeeStatuses.Confirmed).Sum(t => t.Training.Duration) / 60,
                })
                .FirstOrDefaultAsync();

            return profile;
        }
    }
}
