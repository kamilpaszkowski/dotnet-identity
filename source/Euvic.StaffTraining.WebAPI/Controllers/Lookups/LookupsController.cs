using System.Collections.Generic;
using System.Threading.Tasks;
using Euvic.StaffTraining.Contracts.Attendees.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.StaffTraining.WebAPI.Controllers.Lookups
{
    [Route("api/lookups")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LookupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("attendees")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAttendeesLookup.AttendeeSelectItem>))]
        public async Task<IActionResult> GetAttendees()
        {
            var lookup = await _mediator.Send(new GetAttendeesLookup.Query());
            return Ok(lookup);
        }
    }
}
