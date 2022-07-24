using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Attendees.Queries
{
    public static class GetAttendeesList
    {
        public class Query : IQuery<IEnumerable<AttendeesListItem>>
        {
        }

        public class AttendeesListItem
        {
            public long Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public int AllowedHours { get; set; }
            public double TotalHours { get; set; }
            public double TotalConfirmedHours { get; set; }
        }
    }
}
