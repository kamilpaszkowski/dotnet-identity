using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Features.Trainings.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.UpdateTraining;

namespace Euvic.StaffTraining.Features.Trainings.Commands.UpdateTraining
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
            var training = await _context.Trainings.FirstOrDefaultAsync(t => t.Id == request.Id);

            if (training == null)
                throw new TrainingNotFoundException(request.Id, "Training not found", $"Training with id {request.Id} not found");

            training.LecturerId = request.LecturerId;
            training.Title = request.Title;
            training.Description = request.Description;
            training.Duration = request.Duration;
            training.TechnologyId = request.TechnologyId;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
