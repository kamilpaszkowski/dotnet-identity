
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Contracts.Technologies.Shared;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Technologies.Queries.GetTechnologiesList;

namespace Euvic.StaffTraining.Features.Techologies.Queries.GetTechnologiesList
{
    internal class Handler : IQueryHandler<Contract.Query, IEnumerable<Contract.TechnologyListItem>>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contract.TechnologyListItem>> Handle(Contract.Query request, CancellationToken cancellationToken)
        {
            var technologies = await _context.Technologies
                   .Select(x =>
                   new Contract.TechnologyListItem()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Scope = x.Scope.ToEnum<TechnologyScope>()
                   })
                   .ToListAsync();

            return technologies;
        }
    }
}
