using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Lecturers.Queries.GetLecturerTrainingsSummary;

namespace Euvic.StaffTraining.Features.Lecturers.Queries.GetLecturerTrainingsSummary
{
    internal class Handler : IQueryHandler<Contract.Query, Dictionary<string, int>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var summary = await _context.Lecturers
              .Include(x => x.Trainings)
              .Where(x => x.Id == request.LecturerId)
              .SelectMany(x => x.Trainings)
              .GroupBy(x => x.Technology.Name)
              .Select(x => new { Technology = x.Key, Count = x.Count() })
              .ToDictionaryAsync(key => key.Technology, value => value.Count);

            return summary;
        }
    }
}
