using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Euvic.StaffTraining.Common
{
    public static class PrincipalExtensions
    {
        public const string AttendeeIdClaim = "attendeeId";
        public const string LecturerIdClaim = "lecturerId";
        public const string PermissionsClaim = "permissions";

        public static string GetUserEmail(this IPrincipal principal)
            => principal.GetClaimValue("email") ?? string.Empty;

        public static long? GetLecturerId(this IPrincipal principal)
        {
            long lecturerId = 0;
            var userClaim = principal.GetClaimValue(LecturerIdClaim);
            if (userClaim != null)
                long.TryParse(userClaim, out lecturerId);

            return lecturerId > 0 ? lecturerId : null;
        }

        public static IEnumerable<string> GetPermissions(this IPrincipal principal) => principal.GetClaimsValue(PermissionsClaim);

        public static long? GetAttendeeId(this IPrincipal principal)
        {
            long attendeeId = 0;
            var userClaim = principal.GetClaimValue(AttendeeIdClaim);
            if (userClaim != null)
                long.TryParse(userClaim, out attendeeId);

            return attendeeId > 0 ? attendeeId : null;
        }

        public static long? GetUserId(this IPrincipal principal)
        {
            long userId = 0;
            var userClaim = principal.GetClaimValue(ClaimTypes.NameIdentifier);
            if (userClaim != null)
                long.TryParse(userClaim, out userId);

            return userId > 0 ? userId : null;
        }

        private static string GetClaimValue(this IPrincipal principal, string claimName)
        {
            if (IsAuthenticated(principal) && principal.Identity is ClaimsIdentity claimsIdentity)
            {
                var clientIdClaim = claimsIdentity.FindFirst(claimName);

                return clientIdClaim?.Value;
            }

            return null;
        }

        private static IEnumerable<string> GetClaimsValue(this IPrincipal principal, string claimName)
        {
            if (IsAuthenticated(principal) && principal.Identity is ClaimsIdentity claimsIdentity)
            {
                var clientIdClaim = claimsIdentity.FindAll(claimName);

                return clientIdClaim?.Select(x => x.Value);
            }

            return null;
        }

        private static bool IsAuthenticated(IPrincipal principal)
            => principal.Identity?.IsAuthenticated ?? false;
    }
}
