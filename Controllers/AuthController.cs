using Microsoft.AspNetCore.Mvc;

namespace UspgPOS.Controllers
{
    public class AuthController : Controller
    {

        public AuthController() { }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
