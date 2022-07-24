using Euvic.StaffTraining.Common;

namespace Euvic.StaffTraining.Features.Techologies.Exceptions
{
    internal class TechnologyNotFound : NotFoundException
    {
        public TechnologyNotFound(object entityId, string userMessage, string logMessage) : base(entityId, userMessage, logMessage)
        {
        }
    }
}
