using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Queries
{
    public static class GetLecturerTrainingsSummary
    {
        public class Query : IQuery<Dictionary<string, int>>
        {
            public long LecturerId { get; set; }
        }
    }
}
