using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.CreateTraining;

namespace Euvic.StaffTraining.Features.Trainings.Commands.CreateTrainings
{
    internal class Handler : ICommandHandler<Contract.Command, Guid>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var training = new Training()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Duration = request.Duration,
                TrainingDate = request.StartDate,
                LecturerId = request.LecturerId,
                TechnologyId = request.TechnologyId,
            };

            _context.Trainings.Add(training);
            await _context.SaveChangesAsync();

            return training.Id;
        }
    }
}
