using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Trainings.Queries
{
    public static class GetTrainingAttendees
    {
        public class Query : IQuery<IEnumerable<Attendee>>
        {
            public Guid TrainingId { get; set; }
            public int? StatusId { get; set; }
        }

        public class Attendee
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Status { get; set; }
            public int StatusId { get; set; }
        }
    }
}
