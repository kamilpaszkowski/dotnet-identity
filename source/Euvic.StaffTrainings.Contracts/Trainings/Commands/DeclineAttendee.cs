using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Trainings.Commands
{
    public static class DeclineAttendee
    {
        public class Command : ICommand
        {
            public Guid TrainingId { get; set; }
            public long AttendeeId { get; set; }
        }
    }
}
