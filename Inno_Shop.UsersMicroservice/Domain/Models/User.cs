using System.ComponentModel.DataAnnotations;

namespace Inno_Shop.UsersMicroservice.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        //public string SignInToken { get; set; }
        //public string? RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}
