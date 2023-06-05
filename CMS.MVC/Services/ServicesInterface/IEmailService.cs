using CMS.API.Configuration;
using CMS.API.Models;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IEmailService
    {
        void SendEmail(Message message);
        void SendInvite(EmailDto emailDto);
    }
}
