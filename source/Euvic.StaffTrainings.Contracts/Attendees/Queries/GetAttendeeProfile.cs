using Euvic.Cqrs.Primitives;

namespace Euvic.StaffTraining.Contracts.Attendees.Queries
{
    public class GetAttendeeProfile
    {
        public class Query : IQuery<AttendeeProfile>
        {
        }

        public class AttendeeProfile
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
