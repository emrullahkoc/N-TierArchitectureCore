using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Controllers
{
	[Area("Management")]
	public class SkillController : Controller
    {
        BlogContext db = new BlogContext();
        public IActionResult Index()
        {
            IEnumerable<Skill> model = db.Skill
                .Where(s => s.Status == true && s.Title.Contains("e") && s.Score>50 && s.Description!=null)
                .ToList();
            return View(model);
        }
    }
}
