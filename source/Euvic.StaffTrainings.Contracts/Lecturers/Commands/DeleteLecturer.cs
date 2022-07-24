using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Commands
{
    public static class DeleteLecturer
    {
        public class Command : ICommand
        {
            public long Id { get; set; }
        }
    }
}
