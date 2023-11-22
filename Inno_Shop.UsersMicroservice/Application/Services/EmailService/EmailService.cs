using Inno_Shop.UsersMicroservice.Domain.Models.Dtos;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Inno_Shop.UsersMicroservice.Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("magdalen.zemlak92@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Plain) { Text = request.Body };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("magdalen.zemlak92@ethereal.email", "957wGzHUtzHNRN1KyA");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
