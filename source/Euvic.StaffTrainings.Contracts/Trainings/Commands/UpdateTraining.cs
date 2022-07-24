using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Trainings.Commands
{
    public static class UpdateTraining
    {
        public class Command : ICommand
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Duration { get; set; }
            public DateTime StartDate { get; set; }
            public long LecturerId { get; set; }
            public long TechnologyId { get; set; }
        }
    }
}
