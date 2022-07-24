using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Lecturers.Queries.GetLecturersList;

namespace Euvic.StaffTraining.Features.Lecturers.Queries.GetLecturersList
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.LecturerListItem>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contract.LecturerListItem>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            TechnologyScope? scope = request.Scope.HasValue
                ? request.Scope.Value.ToEnum<TechnologyScope>()
                : null;

            var lecturers = await _context.Lecturers
                .Include(x => x.Trainings)
                    .ThenInclude(x => x.Technology)
                .Where(x => string.IsNullOrEmpty(request.SearchPhase) || (x.Firstname.Contains(request.SearchPhase) || x.Lastname.Contains(request.SearchPhase)))
                .Where(x => !request.Scope.HasValue || x.Trainings.Any(t => t.Technology.Scope == scope.Value))
                .Select(x =>
                new Contract.LecturerListItem()
                {
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    TotalTrainings = x.Trainings.Count(),
                    Technologies = x.Trainings.Select(x => x.Technology.Name)
                })
                .ToListAsync();

            return lecturers;
        }
    }
}
