namespace Euvic.StaffTraining.Identity.Abstractions
{
    public interface IIdentityProvider
    {
        Task CreateAttendeeUserAsync(string email, string password, long attendeeId);
        Task CreateHumanResourcesUserAsync(string email, string password, long attendeeId);
        Task CreateLecturerUserAsync(string email, string password, long attendeeId, long lecturerId);

    }
}
