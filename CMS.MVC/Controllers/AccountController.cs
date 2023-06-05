using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult FacilitatorLogin()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ConfirmPassword()
        {
            return View();
        }

        public IActionResult PermissionDecadev()
        {
            return View();
        }

        public IActionResult PermissionFacilitator()
        {
            return View();
        }

        public IActionResult SuccessInvite()
        {
            return View();
        }
    }
}
