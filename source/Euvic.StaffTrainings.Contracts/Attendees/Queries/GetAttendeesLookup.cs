using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Contracts.Shared;

namespace Euvic.StaffTraining.Contracts.Attendees.Queries
{
    public static class GetAttendeesLookup
    {
        public class Query : IQuery<IEnumerable<AttendeeSelectItem>>
        {
        }

        public class AttendeeSelectItem : SelectItem<long>
        {
        }
    }
}
