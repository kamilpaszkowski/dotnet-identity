using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Commands
{
    public static class CreateLecturer
    {
        public class Command : ICommand<long>
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
