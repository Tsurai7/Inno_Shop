using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

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
    }
}
