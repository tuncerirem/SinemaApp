using Microsoft.AspNetCore.Mvc;

namespace SinemaApp.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}
