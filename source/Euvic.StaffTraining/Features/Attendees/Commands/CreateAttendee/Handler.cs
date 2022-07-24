
using Euvic.Cqrs.Primitives;
using Euvic.StaffTraining.Domain;
using Euvic.StaffTraining.Features.Attendees.Exceptions;
using Euvic.StaffTraining.Identity.Abstractions;
using Euvic.StaffTraining.Infrastructure.EntityFramework;
using Contract = Euvic.StaffTraining.Contracts.Attendees.Commands.CreateAttendee;

namespace Euvic.StaffTraining.Features.Attendees.Commands.CreateAttendee
{
    internal class Handler : ICommandHandler<Contract.Command, long>
    {
        private readonly StaffTrainingContext _context;
        private readonly IIdentityProvider _identityProvider;

        public Handler(IIdentityProvider identityProvider, StaffTrainingContext context)
        {
            _identityProvider = identityProvider;
            _context = context;
        }

        public async Task<long> Handle(Contract.Command request, CancellationToken cancellationToken)
        {
            var attendee = new Attendee()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                AllowedHours = 8
            };

            _context.Attendees.Add(attendee);

            await _context.SaveChangesAsync();
            await CreateIdentityProviderUserAsync(request, attendee);

            return attendee.Id;
        }

        private async Task CreateIdentityProviderUserAsync(Contract.Command request, Attendee attendee)
        {
            try
            {
                if (!request.IsHumanResourcesUser)
                    await _identityProvider.CreateAttendeeUserAsync(request.Email, request.Password, attendee.Id);
                else
                    await _identityProvider.CreateHumanResourcesUserAsync(request.Email, request.Password, attendee.Id);
            }
            catch
            {
                _context.Attendees.Remove(attendee);
                await _context.SaveChangesAsync();

                throw new AttendeeCreationFailedException("System could not create identity by identity provider");
            }
        }
    }
}
