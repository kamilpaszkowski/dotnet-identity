using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Technologies.Commands
{
    public static class DeleteTechnology
    {
        public class Command : ICommand
        {
            public int TechnologyId { get; set; }
        }
    }
}
