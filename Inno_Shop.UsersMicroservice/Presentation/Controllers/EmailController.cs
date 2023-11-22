using Inno_Shop.UsersMicroservice.Application.Services.EmailService;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);

            return Ok();
        }
    }
}
