using Microsoft.AspNetCore.Mvc;
using Inno_Shop.UsersMicroservice.Application.Services.TokenService;
using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Inno_Shop.UsersMicroservice.Domain.Interfaces;
using Inno_Shop.UsersMicroservice.Application.Services.EmailService;
using System.Security.Cryptography;
using Inno_Shop.Services.Users.Domain.Models.Entities;

namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AccountController(IUserRepository repository, ITokenService tokenService, 
            IEmailService emailService)
        {
            _repository = repository;
            _tokenService = tokenService;
            _emailService = emailService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _repository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }

            if (user.VerifiedAt == null)
            {
                return BadRequest("User not verified");
            }

            return Ok("Welcome back");
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if(_repository.GetUserByEmailAsync(request.Email) != null)
            {
                return BadRequest("User already exists");
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var token = _tokenService.BuildToken(request.Name);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = token,
                CreatedAt = DateTime.Now
            };

            _repository.AddUserAsync(user);
            _repository.SaveAsync();

            return Ok(user);
        }


        //[HttpPost("verify")]
        //public async Task<IActionResult> Verify(string token)
        //{

        //}

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }















        //[AllowAnonymous]
        //[HttpPost("forgot-password")]
        //public async IActionResult ForgotPassword(string email)
        //{
        //    var user = await _userRepository.GetUserAsync(email);

        //    if (user == null)
        //    {
        //        return BadRequest("User not found");
        //    }

        //    user.Password
        //}
    }
}
