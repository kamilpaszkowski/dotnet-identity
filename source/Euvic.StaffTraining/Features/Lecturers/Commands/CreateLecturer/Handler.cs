
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Identity.Abstractions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Microsoft.Extensions.Logging;
using Contract = Euvic.StaffTraining.Contracts.Lecturers.Commands.CreateLecturer;

namespace Euvic.StaffTraining.Features.Attendees.Commands.CreateLecturer
{
    internal class Handler : ICommandHandler<Contract.Command, long>
    {
        private readonly StaffTrainingContext _context;
        private readonly IIdentityProvider _identityProvider;
        private readonly ILogger<Handler> _logger;

        public Handler(IIdentityProvider identityProvider, StaffTrainingContext context, ILogger<Handler> logger)
        {
            _identityProvider = identityProvider;
            _context = context;
            _logger = logger;
        }

        public async Task<long> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var lecturer = new Lecturer()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };

            var attendee = new Attendee()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                AllowedHours = 8
            };

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Attendees.Add(attendee);
                _context.Lecturers.Add(lecturer);

                await _context.SaveChangesAsync();

                await _identityProvider.CreateLecturerUserAsync(request.Email, request.Password, attendee.Id, lecturer.Id);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "It was an exception during creating lecturer");
                await transaction.RollbackAsync();
                throw;
            }

            return lecturer.Id;
        }
    }
}
