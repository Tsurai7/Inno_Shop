using Microsoft.AspNetCore.Mvc;
using Inno_Shop.UsersMicroservice.Application.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Application.Services.EmailService;
using System.Security.Cryptography;
using Inno_Shop.Services.Users.Domain.Models.Entities;
using Inno_Shop.Services.Users.Domain.Models.Dtos;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Inno_Shop.Services.Users.Application.Services.AuthService;
using Org.BouncyCastle.Asn1.Cms;
using Inno_Shop.Services.Users.Application.Dtos;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;


        public AccountController(IUserRepository repository, ITokenService tokenService, 
            IEmailService emailService, IAuthService authService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _emailService = emailService;
            _authService = authService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _repository.GetUserByEmailAsync(request.Email);

            if (user == null)
                return BadRequest("Bad credentials");
            

            if (!_authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Bad credentials");
            

            if (user.VerifiedAt == null)
                return BadRequest("Bad credentials");
            

            var accessToken = _tokenService.BuildToken(user.Name);
            var refreshToken = _tokenService.BuildToken(user.Name);

            return Ok(new AuthResponseDto
            {
                Username = user.Name,
                Email = user.Email,
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if(await _repository.GetUserByEmailAsync(request.Email) != null)
                return BadRequest("User already exists");
            

            _authService.CreatePasswordHash(request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var accessToken = _tokenService.BuildToken(request.Name);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = accessToken,
                CreatedAt = DateTime.Now
            };

            await _repository.AddUserAsync(user);
            await _repository.SaveAsync();

            await _emailService.SendConfirmationEmailAsync(request.Email, accessToken);

            return Ok(new AuthResponseDto
            {
                Username = request.Name,
                Email = request.Email,
                Token = accessToken,
                RefreshToken = string.Empty
            });
        }


        [AllowAnonymous]
        [HttpGet("verify")]
        public async Task<IActionResult> Verify([FromQuery] string token)
        {
            var user = await _repository.GetUserByTokenAsync(token);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            user.VerifiedAt = DateTime.Now;
            await _repository.SaveAsync();

            return Ok("Email confirmed successfully.");
        }
    }
}
