using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.Contracts.Technologies.Commands
{
    public static class CreateTechnology
    {
        public class Command : ICommand<long>
        {
            public string Name { get; set; }
            public TechnologyScope Scope { get; set; }
        }
    }
}
