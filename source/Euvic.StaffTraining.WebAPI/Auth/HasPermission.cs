using Microsoft.AspNetCore.Authorization;

namespace Euvic.StaffTraining.WebAPI.Auth
{
    public class HasPermission : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public HasPermission(string name)
        {
            Name = name;
        }
    }
}
