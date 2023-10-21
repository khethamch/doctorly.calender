using doctorly.calender.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace doctorly.calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmail _email;

        public EmailsController(IEmail _email)
        {
            this._email = _email;
        }

        /// <summary>
        /// Confirming if the attendee is come to the event.
        /// </summary>
        /// <param name="email">The email address the mail will be sent to.</param>
        /// <param name="subject">The subject for the email to be sent.</param>
        /// <param name="body">The body of the email to be sent.</param>
        /// <returns>The empty result.</returns>
        [HttpPost]
        [Route("send-email")]
        public async Task<IActionResult> SendEmail([FromQuery] string email, string subject, string body)
        {
            try
            {
                await _email.Send(email, subject, body);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
