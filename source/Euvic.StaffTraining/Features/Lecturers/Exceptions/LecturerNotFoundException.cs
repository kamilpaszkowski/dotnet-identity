using Euvic.StaffTraining.Common;

namespace Euvic.StaffTraining.Features.Lecturers.Exceptions
{
    internal class LecturerNotFoundException : NotFoundException
    {
        public LecturerNotFoundException(object entityId, string userMessage, string logMessage) : base(entityId, userMessage, logMessage)
        {
        }
    }
}
