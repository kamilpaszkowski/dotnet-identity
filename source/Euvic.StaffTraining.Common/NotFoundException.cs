using System;

namespace Euvic.StaffTraining.Common
{
    public abstract class NotFoundException : Exception
    {
        public object EntityId { get; }
        public string UserMessage { get; }
        public string LogMessage { get; }

        protected NotFoundException(object entityId, string userMessage, string logMessage)
        {
            EntityId = entityId;
            UserMessage = userMessage;
            LogMessage = logMessage;
        }
    }
}
