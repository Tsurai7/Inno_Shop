using System.ComponentModel.DataAnnotations;

namespace Inno_Shop.Services.Users.Domain.Models.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public string? PasswordResetToken { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
    }
}
