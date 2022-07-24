using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;

namespace Euvic.StaffTraining.Contracts.Trainings.Queries
{
    public static class GetTrainingsList
    {
        [MeasurePerformance]
        public class Query : IQuery<IEnumerable<TrainingListItem>>
        {
            public DateTime? From { get; set; }
            public DateTime? To { get; set; }
            public long? LecturerId { get; set; }
        }

        public class TrainingListItem
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Duration { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime TrainingDate { get; set; }
            public long LecturerId { get; set; }
            public string LecturerFullName { get; set; }
            public long TechnologyId { get; set; }
            public string TechnologyName { get; set; }
            public int ConfirmedAttendances { get; set; }
            public int TotalAttendances { get; set; }
            public int AttendanceStatusId { get; set; }
        }

    }
}
