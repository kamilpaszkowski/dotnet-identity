using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Attendees.Commands
{
    public static class DeleteAttendee
    {
        public class Command : ICommand
        {
            public long Id { get; set; }
        }
    }
}
