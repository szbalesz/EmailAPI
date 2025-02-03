using EmailAPI.Models.Dtos;
using EmailAPI.Services.IEmailService;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace EmailAPI.Services
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailRequestDto emailRequestDto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailSettings:EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(emailRequestDto.To));
            email.Subject = emailRequestDto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailRequestDto.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailSettings:EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailSettings:EmailUsername").Value, _configuration.GetSection("EmailSettings:EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
