using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;
using MyBlog.Web.Models.ViewModels;

namespace MyBlog.Web.Areas.Management.Controllers
{
	[Area("Management")]
	public class DashboardController : Controller
	{
		BlogContext db = new BlogContext ();
		public IActionResult Index()
		{
			var model = new DashboardViewModel ();
			model.ArticleCount = db.Articles.Count (x => x.Status==true);
            model.SkillCount = db.Skill.Count(x => x.Status == true);
            model.ProjectCount = db.Projects.Count(x => x.Status == true);
			model.Articles = db.Articles
				.Where(x => x.Status == true)
				.OrderByDescending(x => x.CreatedDate) //sondan sıralama yapıyor
				.Take(1).ToList(); //Take 5 tanesini al demek

            return View();
		}
	}
}
