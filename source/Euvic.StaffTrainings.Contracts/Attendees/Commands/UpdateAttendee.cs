using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Attendees.Commands
{
    public static class UpdateAttendee
    {
        public class Command : ICommand
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public int AllowedHours { get; set; }
        }
    }
}
