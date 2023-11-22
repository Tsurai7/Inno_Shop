using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Inno_Shop.UsersMicroservice.Application.Services.TokenService;
using Inno_Shop.UsersMicroservice.Application.Services.UserService;
using Inno_Shop.UsersMicroservice.Domain.Models;
using Inno_Shop.UsersMicroservice.Infrastucture.Repositories;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Application.Services.EmailService;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AccountController(IUserRepository userRepository, ITokenService tokenService, 
            IConfiguration configuration, IEmailService emailService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
            _emailService = emailService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody] LoginRequestDto request)
        {

            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid request data");
            }

            var userDto = _userRepository.AuthUser(request.Email, request.Password);

            if (userDto == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.BuildToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                userDto);

            return Ok(new { Token = token });
        }

       
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid request data");
            }

            if (_userRepository.GetUserAsync(request.Email) == null)
            {
                return BadRequest("User with this email already exists");
            }

            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
                EmailConfirmationToken = Guid.NewGuid().ToString()
            };

            _userRepository.AddUserAsync(newUser);
            _userRepository.SaveAsync();

            // Теперь вы можете включить автоматическую аутентификацию пользователя после регистрации,
            // создавая токен и отправляя его обратно клиенту

            var token = _tokenService.BuildToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                newUser);

            _emailService.SendConfirmationEmailAsync(request.Email, newUser.EmailConfirmationToken);

            return Ok(new { Token = token });
        }
    }
}
