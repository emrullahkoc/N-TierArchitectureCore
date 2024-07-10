using Microsoft.AspNetCore.Mvc;

namespace NTierArchitectureCore.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
