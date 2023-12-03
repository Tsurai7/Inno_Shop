namespace Inno_Shop.UsersMicroservice.Presentation.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService  _userService;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;


        public AccountController(IUserService userService, ITokenService tokenService, 
            IEmailService emailService, IAuthService authService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _emailService = emailService;
            _authService = authService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

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
            if(await _userService.GetByEmailAsync(request.Email) != null)
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

            await _userService.AddAsync(user);

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
            var user = await _userService.GetByTokenAsync(token);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            user.VerifiedAt = DateTime.Now;

            return Ok("Email confirmed successfully.");
        }
    }
}
