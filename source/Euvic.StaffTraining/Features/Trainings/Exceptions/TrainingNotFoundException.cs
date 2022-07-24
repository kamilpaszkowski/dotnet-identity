using Euvic.StaffTraining.Common;

namespace Euvic.StaffTraining.Features.Trainings.Exceptions
{
    internal class TrainingNotFoundException : NotFoundException
    {
        public TrainingNotFoundException(object entityId, string userMessage, string logMessage) : base(entityId, userMessage, logMessage)
        {
        }
    }
}
