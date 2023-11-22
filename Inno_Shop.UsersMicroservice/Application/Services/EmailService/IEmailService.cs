using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;

namespace Inno_Shop.UsersMicroservice.Application.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto email);
    }
}
