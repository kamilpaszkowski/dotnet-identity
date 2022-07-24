
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Contract = Euvic.StaffTraining.Contracts.Technologies.Commands.CreateTechnology;

namespace Euvic.StaffTraining.Features.Techologies.Commands.CreateTechnology
{
    internal class Handler : ICommandHandler<Contract.Command, long>
    {
        private readonly StaffTrainingContext _context;

        public Handler(StaffTrainingContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var technology = new Technology()
            {
                Name = request.Name,
                Scope = request.Scope.ToEnum<TechnologyScope>()
            };

            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();

            return technology.Id;
        }
    }
}
