using CMS.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.MVC.Controllers
{
    public class ClassroomController : Controller
    {
        public bool toggleState { get; set; } = false;

        [HttpGet]
        public IActionResult LearningContent()
        {
            ViewBag.ShowSuccessModal = toggleState;

            return View();
        }

        [HttpGet]
        public IActionResult QuizPage()
        {
            ViewBag.ShowSuccessModal = toggleState;

            return View();
        }
        public IActionResult ResourcePage()
        {
            var result = new CKEditor();
            return View(result);
        }
        public IActionResult QuizScore()
        {
            return View();
        }
    }
}
