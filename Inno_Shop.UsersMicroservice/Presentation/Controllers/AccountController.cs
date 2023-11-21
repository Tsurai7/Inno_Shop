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
    }
}
