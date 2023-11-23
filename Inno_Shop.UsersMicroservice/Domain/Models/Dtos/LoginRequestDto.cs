using System.ComponentModel.DataAnnotations;

namespace Inno_Shop.UsersMicroservice.Domain.Models.Dtos
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
