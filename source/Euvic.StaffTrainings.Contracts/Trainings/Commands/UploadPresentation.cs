using Euvic.Cqrs.Primitives;
using Microsoft.AspNetCore.Http;

namespace Euvic.StaffTraining.Contracts.Trainings.Commands
{
    public static class UploadPresentation
    {
        public class Command : ICommand
        {
            public Guid TrainingId { get; set; }
            public IFormFile Presentation { get; set; }
        }
    }
}
