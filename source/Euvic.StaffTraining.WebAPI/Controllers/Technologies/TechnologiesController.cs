using System.Collections.Generic;
using System.Threading.Tasks;
using Euvic.StaffTraining.Contracts.Technologies.Queries;
using Euvic.StaffTraining.WebAPI.Controllers.Technologies.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.StaffTraining.WebAPI.Controllers.Technologies
{
    [Route("api/technologies")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnologiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetTechnologiesList.TechnologyListItem>))]
        public async Task<IActionResult> GetTechnologies()
        {
            var technologies = await _mediator.Send(new GetTechnologiesList.Query());
            return Ok(technologies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        public async Task<IActionResult> CreateTechnology([FromBody] CreateTechnologyRequest request)
        {
            var technologyId = await _mediator.Send(new Contracts.Technologies.Commands.CreateTechnology.Command()
            {
                Name = request.Name,
                Scope = request.Scope
            });

            return Ok(technologyId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateTechnology([FromRoute] long id, [FromBody] UpdateTechnologyRequest request)
        {
            await _mediator.Send(new Contracts.Technologies.Commands.UpdateTechnology.Command()
            {
                TechnologyId = id,
                Name = request.Name,
                Scope = request.Scope
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTechnology([FromRoute] long id)
        {
            await _mediator.Send(new Contracts.Technologies.Commands.UpdateTechnology.Command()
            {
                TechnologyId = id
            });

            return NoContent();
        }
    }
}
