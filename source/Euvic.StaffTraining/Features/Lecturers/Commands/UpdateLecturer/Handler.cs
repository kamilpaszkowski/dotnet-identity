
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Features.Lecturers.Exceptions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Contract = Euvic.StaffTraining.Contracts.Lecturers.Commands.UpdateLecturer;

namespace Euvic.StaffTraining.Features.Lecturers.Commands.UpdateLecturer
{
    internal class Handler : ICommandHandler<Contract.Command>
    {
        private readonly StaffTrainingContext _context;

        public async Task<Unit> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var lecturer = await _context.Lecturers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (lecturer == null)
                throw new LecturerNotFoundException(request.Id, "Lecturer not found", $"Lecturer with Id {request.Id} not found");

            lecturer.Firstname = request.Firstname;
            lecturer.Lastname = request.Lastname;

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
