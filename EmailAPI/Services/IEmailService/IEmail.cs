using EmailAPI.Models.Dtos;

namespace EmailAPI.Services.IEmailService
{
    public interface IEmail
    {
        void SendEmail(EmailRequestDto emailRequestDto);
    }
}
