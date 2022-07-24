using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Attendees.Commands
{
    public static class CreateAttendee
    {
        public class Command : ICommand<long>
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsHumanResourcesUser { get; set; }
        }
    }
}
