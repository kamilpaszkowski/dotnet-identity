using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.Contracts.Technologies.Queries
{
    public static class GetTechnologiesList
    {
        public class Query : IQuery<IEnumerable<TechnologyListItem>>
        {
        }

        public class TechnologyListItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public TechnologyScope Scope { get; set; }
        }
    }
}
