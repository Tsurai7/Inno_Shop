using Inno_Shop.UsersMicroservice.Application.Services.EmailService;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public EmailController(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }


        [HttpPost("send")]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);

            return Ok();
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            var user = _userRepository.IsEmailConfirmed(token);

            if (user == null)
            {
                return BadRequest(new { Message = "Invalid token." });
            }

            user.IsEmailConfirmed = true;
            user.EmailConfirmationToken = null;
            await _userRepository.SaveAsync();

            return Ok(new { Message = "Email confirmed successfully." });
        }
    }
}
