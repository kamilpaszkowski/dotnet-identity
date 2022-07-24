using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Technologies.Queries
{
    public static class GetTechnologiesLookup
    {
        public class Query : IQuery<IEnumerable<TechnologySelectItem>>
        {

        }

        public class TechnologySelectItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
