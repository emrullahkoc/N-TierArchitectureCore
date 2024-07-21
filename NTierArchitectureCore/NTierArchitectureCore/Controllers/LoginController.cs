using Microsoft.AspNetCore.Mvc;

namespace NTierArchitectureCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
