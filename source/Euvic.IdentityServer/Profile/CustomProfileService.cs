using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityServerHost.Models;
using Microsoft.AspNetCore.Identity;

namespace Euvic.IdentityServer.Profile
{
    public class CustomProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;

        public CustomProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim("attendeeId", user.AttendeeId.ToString()),
            };

            if (user.LecturerId.HasValue)
            {
                claims.Add(new Claim("lecturerId", user.LecturerId.ToString()));
                claims.Add(new Claim("permissions", "CanDeleteTraining"));
            }

            foreach (var role in roles)
            {
                claims.Add(new Claim("euvic-roles", role));
            }

            context.IssuedClaims.AddRange(claims);
        }

        public Task IsActiveAsync(IsActiveContext context) => Task.FromResult(true);
    }
}
