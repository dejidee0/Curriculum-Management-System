using CMS.API.Models;
using CMS.MVC.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
