using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;

namespace Inno_Shop.UsersMicroservice.Application.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailConfirmationDto email);

        Task SendConfirmationEmailAsync(string email, string token);

        Task SendPasswordRecovery(string email);
    }
}
