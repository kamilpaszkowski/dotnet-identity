using System.Net.Http.Json;
using Euvic.StaffTraining.Identity.Abstractions;

namespace Euvic.StaffTraining.Identity.Infrastructure.Identity
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly HttpClient _httpClient;

        public IdentityProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAttendeeUserAsync(string email, string password, long attendeeId)
        {
            var requestModel = new CreateAccountModel()
            {
                Email = email,
                Password = password,
                AttendeeId = attendeeId,
                Roles = new List<UserRoles>()
                {
                    UserRoles.Attendee,
                }
            };

            var response = await _httpClient.PostAsync("/api/accounts", JsonContent.Create(requestModel));
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateHumanResourcesUserAsync(string email, string password, long attendeeId)
        {
            var requestModel = new CreateAccountModel()
            {
                Email = email,
                Password = password,
                AttendeeId = attendeeId,
                Roles = new List<UserRoles>()
                {
                    UserRoles.Attendee,
                    UserRoles.HR
                }
            };

            var response = await _httpClient.PostAsync("/api/accounts", JsonContent.Create(requestModel));
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateLecturerUserAsync(string email, string password, long attendeeId, long lecturerId)
        {
            var requestModel = new CreateAccountModel()
            {
                Email = email,
                Password = password,
                AttendeeId = attendeeId,
                LecturerId = lecturerId,
                Roles = new List<UserRoles>()
                {
                    UserRoles.Attendee,
                    UserRoles.Lecturer
                }
            };

            var response = await _httpClient.PostAsync("/api/accounts", JsonContent.Create(requestModel));
            response.EnsureSuccessStatusCode();
        }
    }
}
