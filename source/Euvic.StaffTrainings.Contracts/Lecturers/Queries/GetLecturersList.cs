using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Contracts.Technologies.Shared;

namespace Euvic.StaffTraining.Contracts.Lecturers.Queries
{
    public static class GetLecturersList
    {
        public class Query : IQuery<IEnumerable<LecturerListItem>>
        {
            public string SearchPhase { get; set; }
            public TechnologyScope? Scope { get; set; }
        }

        public class LecturerListItem
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public IEnumerable<string> Technologies { get; set; }
            public int TotalTrainings { get; set; }
        }
    }
}
