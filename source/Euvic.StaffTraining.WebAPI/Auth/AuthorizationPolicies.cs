namespace Euvic.StaffTraining.WebAPI.Auth
{
    public class AuthorizationPolicies
    {
        public const string HROnlyRestricted = "HR only restricted";
        public const string LecturerOnlyRestricted = "Lecturer only restricted";
        public const string LecturerThatCanDeleteTraining = "Lecturer that can delete training";
    }
}
