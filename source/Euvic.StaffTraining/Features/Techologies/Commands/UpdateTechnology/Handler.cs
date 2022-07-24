
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Features.Techologies.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Technologies.Commands.UpdateTechnology;

namespace Euvic.StaffTraining.Features.Techologies.Commands.UpdateTechnology
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
            var technology = await _context.Technologies.FirstOrDefaultAsync(x => x.Id == request.TechnologyId);
            if (technology == null)
                throw new TechnologyNotFound(request.TechnologyId, "Technology not found", $"Technology with Id {request.TechnologyId} not found");

            technology.Name = request.Name;
            technology.Scope = request.Scope.ToEnum<TechnologyScope>();

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
