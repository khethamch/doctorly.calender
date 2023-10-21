using doctorly.calender.Model;
using doctorly.calender.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace doctorly.calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEvent _event;

        public EventsController(IEvent _event)
        {
            this._event = _event;
        }

        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="eventModel">The model to create the event.</param>
        /// <returns>The empty result.</returns>
        [HttpPost]
        [Route("create-event")]
        public async Task<IActionResult> CreateEvent([FromBody] EventModel eventModel)
        {
            try
            {
                await _event.CreateEvent(eventModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update an event
        /// </summary>
        /// <param name="eventModel">The model to update the event.</param>
        /// <returns>The empty result.</returns>
        [HttpPut]
        [Route("update-event")]
        public async Task<IActionResult> UpdateEvent([FromBody] EventModel eventModel)
        {
            try
            {
                await _event.UpdateEvent(eventModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete an event
        /// </summary>
        /// <param name="eventId">The event id to be deleted.</param>
        /// <returns>The empty result.</returns>
        [HttpDelete]
        [Route("delete-event")]
        public async Task<IActionResult> DeleteEvent([FromQuery] int eventId)
        {
            try
            {
                await _event.DeleteEvent(eventId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get events from the database
        /// </summary>
        /// <param name="search">The search to filter the result set from the database.</param>
        /// <returns>The list of events</returns>
        [HttpGet]
        [Route("get-events")]
        public async Task<IActionResult> GetEvents([FromQuery] string search)
        {
            try
            {
                return Ok(await _event.GetEvents(search));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get event from the database
        /// </summary>
        /// <param name="eventId">The eventId to get the event matches the id from the database.</param>
        /// <returns>The object of event</returns>
        [HttpGet]
        [Route("get-event")]
        public async Task<IActionResult> GetEvent([FromQuery] int eventId)
        {
            try
            {
                return Ok(await _event.GetEvent(eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get attendees for an event from the database
        /// </summary>
        /// <param name="eventId">The eventId to get attendees for the event from the database.</param>
        /// <returns>The object of event</returns>
        [HttpGet]
        [Route("get-event-attendees")]
        public async Task<IActionResult> GetEventAttendees([FromQuery] int eventId)
        {
            try
            {
                return Ok(await _event.GetEventAttendees(eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cancel the event from the database
        /// </summary>
        /// <param name="eventId">The eventId to cancel event from the database.</param>
        /// <returns>The object of event</returns>
        [HttpPatch]
        [Route("cancel-event")]
        public async Task<IActionResult> CancelEvent([FromQuery] int eventId)
        {
            try
            {
                await _event.CancelEvent(eventId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
