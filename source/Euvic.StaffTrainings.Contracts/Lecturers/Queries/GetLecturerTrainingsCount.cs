using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Queries
{
    public static class GetLecturerTrainingsCount
    {
        public class Query : IQuery<int>
        {
            public long LecturerId { get; set; }
        }
    }
}
