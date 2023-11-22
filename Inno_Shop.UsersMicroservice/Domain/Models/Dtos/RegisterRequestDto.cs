namespace Inno_Shop.UsersMicroservice.Domain.Models.Dtos
{
    public class RegisterRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Дополнительные свойства, если необходимо
    }
}
