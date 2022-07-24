using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.Contracts.Technologies.Commands
{
    public static class UpdateTechnology
    {
        public class Command : ICommand
        {
            public long TechnologyId { get; set; }
            public string Name { get; set; }
            public TechnologyScope Scope { get; set; }
        }
    }
}
