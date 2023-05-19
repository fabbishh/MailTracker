using MailTracker.Application.Dto;
using MailTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MailTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> PostMailAsync([FromBody] AddEmailRequest mail)
        {

            await _emailService.SaveEmail(mail);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmailsResponse>>> GetEmailsAsync()
        {
            var response = await _emailService.GetAllEmailsAsync();
            return Ok(response);
        }
    }
}
