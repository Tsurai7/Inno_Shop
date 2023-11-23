namespace Inno_Shop.UsersMicroservice.Domain.Models.Dtos
{
    public class EmailConfirmationDto
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
