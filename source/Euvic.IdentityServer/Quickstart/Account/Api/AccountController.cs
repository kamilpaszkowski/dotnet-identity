using System.Linq;
using System.Threading.Tasks;
using IdentityServerHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.IdentityServer.Quickstart.Account.Api
{
    [Route("api/accounts")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true,
                AttendeeId = model.AttendeeId,
                LecturerId = model.LecturerId,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, model.Roles.Select(x => x.ToString()));

            return result.Succeeded ? Ok(user.Id) : BadRequest(result.Errors);
        }
    }
}
