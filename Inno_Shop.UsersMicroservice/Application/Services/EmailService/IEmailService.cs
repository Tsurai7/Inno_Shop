using Inno_Shop.Services.Users.Application.Dtos;

namespace Inno_Shop.UsersMicroservice.Application.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailConfirmationDto email);

        Task SendConfirmationEmailAsync(string email, string token);

        Task SendPasswordRecovery(string email);
    }
}
