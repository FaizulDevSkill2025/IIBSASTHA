using Microsoft.AspNetCore.Mvc;

namespace IIBSASTHA.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
