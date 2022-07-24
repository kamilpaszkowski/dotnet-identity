using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Commands
{
    public static class UpdateLecturer
    {
        public class Command : ICommand
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}
