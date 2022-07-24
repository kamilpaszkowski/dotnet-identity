using Euvic.StaffTraining.Common;

namespace Euvic.StaffTraining.Features.Attendees.Exceptions
{
    internal class AttendeeNotFoundException : NotFoundException
    {
        public AttendeeNotFoundException(object entityId, string userMessage, string logMessage) : base(entityId, userMessage, logMessage)
        {
        }
    }
}
