using doctorly.calender.Model;
using doctorly.calender.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace doctorly.calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private IAttendee _attendee;

        public AttendeesController(IAttendee _attendee)
        {
            this._attendee = _attendee;
        }

        /// <summary>
        /// Creates a new attendee
        /// </summary>
        /// <param name="attendeeModel">The model for the attendee.</param>
        /// <returns>The empty result.</returns>
        [HttpPost]
        [Route("create-attendee")]
        public async Task<IActionResult> CreateAttendee([FromBody] AttendeeModel attendeeModel)
        {
            try
            {
                await _attendee.CreateAttendee(attendeeModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Confirming if the attendee is come to the event.
        /// </summary>
        /// <param name="eventId">The event id to identify event in the database.</param>
        /// <param name="attendeeId">The attendee id to identify attendee in the database.</param>
        /// <param name="isAttending">The bool value to confirm if attending or not.</param>
        /// <returns>The empty result.</returns>
        [HttpPost]
        [Route("confirm-attending-event")]
        public async Task<IActionResult> ConfirmAttendingEvent([FromQuery] int eventId, int attendeeId, bool isAttending)
        {
            try
            {
                await _attendee.ConfirmAttendingEvent(eventId, attendeeId, isAttending);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
