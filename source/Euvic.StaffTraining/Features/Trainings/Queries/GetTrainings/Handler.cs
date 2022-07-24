using System.Security.Principal;
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Queries.GetTrainingsList;

namespace Euvic.StaffTraining.Features.Trainings.Queries.GetTrainings
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.TrainingListItem>>
    {
        private readonly StaffTrainingContext _context;
        private readonly IPrincipal _principal;

        public Handler(StaffTrainingContext context, IPrincipal principal)
        {
            _context = context;
            _principal = principal;
        }

        public async Task<IEnumerable<Contract.TrainingListItem>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var attendeeId = _principal.GetAttendeeId();
            var trainings = await _context.Trainings
                 .Where(x => !request.From.HasValue || x.TrainingDate >= request.From)
                 .Where(x => !request.To.HasValue || x.TrainingDate >= request.To)
                 .Where(x => !request.LecturerId.HasValue || x.LecturerId == request.LecturerId)
                 .Select(x => new Contract.TrainingListItem()
                 {
                     Id = x.Id,
                     LecturerId = x.LecturerId,
                     LecturerFullName = $"{x.Lecturer.Firstname} {x.Lecturer.Lastname}",
                     TrainingDate = x.TrainingDate,
                     CreateDate = x.CreateDate,
                     Duration = x.Duration,
                     Description = x.Description,
                     TechnologyId = x.TechnologyId,
                     TechnologyName = x.Technology.Name,
                     Title = x.Title,
                     ConfirmedAttendances = x.Attendees.Where(x => x.StatusId == (int)TrainingAttendeeStatuses.Confirmed).Count(),
                     TotalAttendances = x.Attendees.Count(),
                     AttendanceStatusId = x.Attendees.Where(x => x.AttendeeId == attendeeId).Select(x => x.StatusId).FirstOrDefault()
                 })
                 .OrderBy(x => x.TrainingDate)
                 .ToListAsync();

            return trainings;
        }
    }
}
