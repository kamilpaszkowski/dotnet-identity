using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Lecturers.Queries.GetLecturerTrainingsCount;

namespace Euvic.StaffTraining.Features.Lecturers.Queries.GetLectuterTrainingsCount
{
    internal class Handler : IQueryHandler<Contract.Query, int>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var trainingsCount = await _context.Trainings
              .Where(x => x.LecturerId == request.LecturerId)
              .CountAsync();

            return trainingsCount;
        }
    }
}
