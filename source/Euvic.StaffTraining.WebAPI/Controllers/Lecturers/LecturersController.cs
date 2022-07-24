using System.Collections.Generic;
using System.Threading.Tasks;
using Euvic.StaffTraining.Contracts.Lecturers.Queries;
using Euvic.StaffTraining.WebAPI.Controllers.Lecturers.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.StaffTraining.WebAPI.Controllers.Lecturers
{
    [Route("api/lecturers")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LecturersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetLecturersList.LecturerListItem>))]
        public async Task<IActionResult> GetLecturers([FromQuery] GetLecturersRequest request)
        {
            var lecturers = await _mediator.Send(new GetLecturersList.Query()
            {
                Scope = request.Scope,
                SearchPhase = request.SearchPhase
            });

            return Ok(lecturers);
        }

        [HttpGet("{lecturerId}/trainings/count")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> GetLecturerTrainingsCount([FromRoute] long lecturerId)
        {
            var trainingsCount = await _mediator.Send(new GetLecturerTrainingsCount.Query()
            {
                LecturerId = lecturerId
            });

            return Ok(trainingsCount);
        }

        [HttpGet("{lecturerId}/trainings/summary")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, int>))]
        public async Task<IActionResult> GetLecturerTrainingsSummary([FromRoute] long lecturerId)
        {
            var summary = await _mediator.Send(new GetLecturerTrainingsSummary.Query()
            {
                LecturerId = lecturerId
            });

            return Ok(summary);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        public async Task<IActionResult> CreateLecturer([FromBody] CreateLecturerRequest request)
        {
            var lecturerId = await _mediator.Send(new Contracts.Lecturers.Commands.CreateLecturer.Command()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Password = request.Password
            });

            return Ok(lecturerId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLecturer([FromRoute] long id, [FromBody] UpdateLecturerRequest request)
        {
            await _mediator.Send(new Contracts.Lecturers.Commands.UpdateLecturer.Command()
            {
                Id = id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteLecturer([FromRoute] long id)
        {
            await _mediator.Send(new Contracts.Lecturers.Commands.DeleteLecturer.Command()
            {
                Id = id,
            });

            return NoContent();
        }
    }
}
