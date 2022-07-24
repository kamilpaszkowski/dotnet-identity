using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Features.Trainings.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.DeleteTraining;

namespace Euvic.StaffTraining.Features.Trainings.Commands.DeleteTraining
{
    internal class Handler : ICommandHandler<Contract.Command>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var training = _context.Trainings.FirstOrDefault(t => t.Id == request.TrainingId);
            if (training == null)
                throw new TrainingNotFoundException(request.TrainingId, "Training not found", $"Training with id {request.TrainingId} not found");

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
