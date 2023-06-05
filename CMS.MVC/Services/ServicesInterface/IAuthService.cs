
using CMS.DATA.DTO;


using CMS.MVC.Services.Implementation;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IAuthService
    {
        Task<ResponseDto<ResetPassword>> ResetPasswords(ResetPassword resetPassword);
        Task<ResponseDto<string>> Logout();
        Task<ResponseDto<string>> ForgotPassword(string email);
    }
}