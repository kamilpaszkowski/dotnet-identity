using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Contract = Euvic.StaffTraining.Contracts.Trainings.Commands.UploadPresentation;

namespace Euvic.StaffTraining.Features.Trainings.Commands.UploadPresentation
{
    internal class Handler : ICommandHandler<Contract.Command>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Add support for StorageAccount");
        }
    }
}
