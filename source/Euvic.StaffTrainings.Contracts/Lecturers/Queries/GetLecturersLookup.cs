using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Lecturers.Queries
{
    public static class GetLecturersLookup
    {
        public class Query : IQuery<IEnumerable<LecturerSelectItem>>
        {

        }

        public class LecturerSelectItem
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }
    }
}
