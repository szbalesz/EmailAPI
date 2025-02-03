using EmailAPI.Models.Dtos;
using EmailAPI.Services.IEmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmail email;

        public EmailsController(IEmail email)
        {
            this.email = email;
        }

        [HttpPost]
        public ActionResult SendNewMail(EmailRequestDto emailRequestDto)
        {
            email.SendEmail(emailRequestDto);
            return Ok(new { message= "Sikeres email küldés" });
        }
    }
}
