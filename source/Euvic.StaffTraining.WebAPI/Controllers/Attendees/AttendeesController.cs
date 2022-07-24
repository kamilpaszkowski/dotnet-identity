using System.Collections.Generic;
using System.Threading.Tasks;
using Euvic.StaffTraining.Contracts.Attendees.Queries;
using Euvic.StaffTraining.WebAPI.Auth;
using Euvic.StaffTraining.WebAPI.Controllers.Attendees.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.StaffTraining.WebAPI.Controllers
{
    [Route("api/attendees")]
    [ApiController]
    [Authorize]
    public class AttendeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAttendeesList.AttendeesListItem>))]
        public async Task<IActionResult> GetAttendees()
        {
            var attendees = await _mediator.Send(new GetAttendeesList.Query());

            return Ok(attendees);
        }

        [HttpGet("me/profile")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAttendeeProfile.AttendeeProfile))]
        public async Task<IActionResult> GetAttendeeProfile()
        {
            var profile = await _mediator.Send(new GetAttendeeProfile.Query());

            return Ok(profile);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        public async Task<IActionResult> CreateAttendee([FromBody] CreateAttendeeRequest request)
        {
            var attendeeId = await _mediator.Send(new Contracts.Attendees.Commands.CreateAttendee.Command()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = request.Password
            });

            return Ok(attendeeId);
        }

        [HttpPost("hr")]
        [Authorize(Policy = AuthorizationPolicies.HROnlyRestricted)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        public async Task<IActionResult> CreateHRAttendee([FromBody] CreateAttendeeRequest request)
        {
            var attendeeId = await _mediator.Send(new Contracts.Attendees.Commands.CreateAttendee.Command()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = request.Password,
                IsHumanResourcesUser = true
            });

            return Ok(attendeeId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAttendee([FromRoute] long id, [FromBody] UpdateAttendeeRequest request)
        {
            await _mediator.Send(new Contracts.Attendees.Commands.UpdateAttendee.Command()
            {
                Id = id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAttendee([FromRoute] long id)
        {
            await _mediator.Send(new Contracts.Attendees.Commands.DeleteAttendee.Command()
            {
                Id = id,
            });

            return NoContent();
        }
    }
}
