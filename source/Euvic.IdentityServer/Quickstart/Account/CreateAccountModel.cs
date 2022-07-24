using System.Collections.Generic;

namespace Euvic.IdentityServer.Quickstart.Account
{
    public class CreateAccountModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public long AttendeeId { get; set; }
        public long? LecturerId { get; set; }
        public string hasHRRole { get; set; }
        public IEnumerable<UserRoles> Roles { get; set; }
    }

    public enum UserRoles
    {
        Attendee,
        Lecturer,
        HR
    }
}
