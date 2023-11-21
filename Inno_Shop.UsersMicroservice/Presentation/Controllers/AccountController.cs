using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Inno_Shop.UsersMicroservice.Application.Services.TokenService;
using Inno_Shop.UsersMicroservice.Application.Services.UserService;
using Inno_Shop.UsersMicroservice.Domain.Models;
using Inno_Shop.UsersMicroservice.Infrastucture.Repositories;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserRepository userRepository, ITokenService tokenService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }


        [HttpPost("login")]
        [AllowAnonymous]
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


        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid request data");
            }

            // Проверяем, не существует ли уже пользователь с таким email
            if (_userRepository.GetUserAsync(request.Email) != null)
            {
                return BadRequest("User with this email already exists");
            }

            // Создаем нового пользователя
            var newUser = new User
            {
                Email = request.Email,
                Password = request.Password,
                // Добавьте другие свойства пользователя, если необходимо
            };

            // Сохраняем пользователя в репозитории
            _userRepository.AddUserAsync(newUser);

            // Теперь вы можете включить автоматическую аутентификацию пользователя после регистрации,
            // создавая токен и отправляя его обратно клиенту

            var token = _tokenService.BuildToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                newUser);

            return Ok(new { Token = token });
        }
    }

}
