using System.Linq;
using System.Threading.Tasks;
using Euvic.StaffTraining.Common;
using Microsoft.AspNetCore.Authorization;

namespace Euvic.StaffTraining.WebAPI.Auth.Handlers
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermission>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermission requirement)
        {
            var permissions = context.User.GetPermissions();
            if (permissions.Contains(requirement.Name))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
