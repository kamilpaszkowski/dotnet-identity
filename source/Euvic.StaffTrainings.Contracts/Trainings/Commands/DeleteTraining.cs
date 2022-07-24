using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Trainings.Commands
{
    public static class DeleteTraining
    {
        public class Command : ICommand
        {
            public Guid TrainingId { get; set; }
        }
    }
}
