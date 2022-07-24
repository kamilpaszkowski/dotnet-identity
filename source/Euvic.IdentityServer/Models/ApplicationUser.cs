﻿using Microsoft.AspNetCore.Identity;

namespace IdentityServerHost.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public long AttendeeId { get; set; }
        public long? LecturerId { get; set; }
    }
}
