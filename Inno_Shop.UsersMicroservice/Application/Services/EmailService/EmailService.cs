using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using static System.Net.WebRequestMethods;

namespace Inno_Shop.UsersMicroservice.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }


        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = request.Body };

            using var smtp = new SmtpClient();

            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value,
                _configuration.GetSection("EmailPassword").Value);

            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task SendConfirmationEmailAsync(string email, string token)
        {
            var message = new MimeMessage();

            message.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "Confirmation email";
            message.Body = new TextPart(TextFormat.Html) { Text =
                $"<a href='{$"https://localhost:7281/api/emai/confirm?token={token}"}'>Click here to confirm your email</a>" };

            using var smtp = new SmtpClient();

            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value,
                _configuration.GetSection("EmailPassword").Value);

            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
