namespace Inno_Shop.Services.Users.Application.Dtos
{
    public class EmailConfirmationDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
