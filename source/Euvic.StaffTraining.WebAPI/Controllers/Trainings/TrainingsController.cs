using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Euvic.StaffTraining.Common;
using Euvic.StaffTraining.Contracts.Trainings.Queries;
using Euvic.StaffTraining.WebAPI.Auth;
using Euvic.StaffTraining.WebAPI.Controllers.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Euvic.StaffTraining.WebAPI.Controllers
{
    [Route("api/trainings")]
    [ApiController]
    [Authorize]
    public class TrainingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPrincipal _principal;

        public TrainingsController(IMediator mediator, IPrincipal principal)
        {
            _mediator = mediator;
            _principal = principal;
        }

        #region Trainings

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetTrainingsList.TrainingListItem>))]
        public async Task<IActionResult> GetTrainings([FromQuery] GetTrainingsRequest request)
        {
            var trainings = await _mediator.Send(new GetTrainingsList.Query()
            {
                From = request.From,
                To = request.To,
                LecturerId = request.LecturerId
            });

            return Ok(trainings);
        }

        [HttpPost]
        [Authorize(Policy = AuthorizationPolicies.LecturerOnlyRestricted)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingRequest request)
        {
            var command = new Contracts.Trainings.Commands.CreateTraining.Command()
            {
                Title = request.Title,
                Description = request.Description,
                Duration = request.Duration,
                StartDate = request.StartDate,
                LecturerId = request.LecturerId,
                TechnologyId = request.TechnologyId,
            };

            var trainingId = await _mediator.Send(command);
            return Ok(trainingId);
        }

        [HttpPost("{id}/presentation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UploadTrainingPresentation(Guid id, [FromForm] UploadTrainingPresentationRequest request)
        {
            var command = new Contracts.Trainings.Commands.UploadPresentation.Command()
            {
                TrainingId = id,
                Presentation = request.Presentation,
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateTraining([FromRoute] Guid id, [FromBody] UpdateTrainingRequest request)
        {
            var command = new Contracts.Trainings.Commands.UpdateTraining.Command()
            {
                LecturerId = request.LecturerId,
                Title = request.Title,
                Description = request.Description,
                Duration = request.Duration,
                TechnologyId = request.TechnologyId
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AuthorizationPolicies.LecturerThatCanDeleteTraining)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTraining([FromRoute] Guid id)
        {
            var command = new Contracts.Trainings.Commands.DeleteTraining.Command()
            {
                TrainingId = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

        #endregion Trainings

        #region Attendees

        [HttpGet("{id}/attendees")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetTrainingAttendees.Attendee>))]
        public async Task<IActionResult> GetTrainingAttendees([FromRoute] Guid id, [FromQuery] int? statusId)
        {
            var query = new GetTrainingAttendees.Query()
            {
                TrainingId = id,
                StatusId = statusId
            };

            var attendees = await _mediator.Send(query);

            return Ok(attendees);
        }

        //[HttpPost("{id}/attendees")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> AddTrainingAttendee([FromRoute] Guid id, [FromBody] long attendeeId)
        //{
        //    var command = new Contracts.Trainings.Commands.AddTrainingAttendee.Command()
        //    {
        //        TrainingId = id,
        //        AttendeeId = attendeeId
        //    };

        //    await _mediator.Send(command);

        //    return NoContent();
        //}

        [HttpPut("{id}/attendees/me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddTrainingAttendee([FromRoute] Guid id)
        {
            var attendeeId = _principal.GetAttendeeId();
            var command = new Contracts.Trainings.Commands.AddTrainingAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId.Value
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/{attendeeId}/confirm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ConfirmAttendee([FromRoute] Guid id, [FromRoute] long attendeeId)
        {
            var command = new Contracts.Trainings.Commands.ConfirmAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/me/confirm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ConfirmAttendee([FromRoute] Guid id)
        {
            var attendeeId = _principal.GetAttendeeId();
            var command = new Contracts.Trainings.Commands.ConfirmAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId.Value
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/{attendeeId}/unconfirm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UnconfirmAttendee([FromRoute] Guid id, [FromRoute] long attendeeId)
        {
            var command = new Contracts.Trainings.Commands.UnconfirmAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/me/unconfirm")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UnconfirmAttendee([FromRoute] Guid id)
        {
            var attendeeId = _principal.GetAttendeeId();
            var command = new Contracts.Trainings.Commands.UnconfirmAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId.Value
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/{attendeeId}/decline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeclineAttendee([FromRoute] Guid id, [FromRoute] long attendeeId)
        {
            var command = new Contracts.Trainings.Commands.DeclineAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId
            };

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/attendees/me/decline")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeclineAttendee([FromRoute] Guid id)
        {
            var attendeeId = _principal.GetAttendeeId();
            var command = new Contracts.Trainings.Commands.DeclineAttendee.Command()
            {
                TrainingId = id,
                AttendeeId = attendeeId.Value
            };

            await _mediator.Send(command);

            return NoContent();
        }

        #endregion Attendees

    }
}
