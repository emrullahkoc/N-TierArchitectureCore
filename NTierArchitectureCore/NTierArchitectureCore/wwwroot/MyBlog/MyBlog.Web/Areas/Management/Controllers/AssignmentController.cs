 

,
,
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class AssignmentController : Controller
    {
        BlogContext db = new BlogContext();

        public IActionResult Index()
        {
            var model = db.Assignments.OrderBy(x => x.DeadLine).ToList();
            ViewBag.AssignmentCount = model.Count();
            return View(model);

        }
    }
}
