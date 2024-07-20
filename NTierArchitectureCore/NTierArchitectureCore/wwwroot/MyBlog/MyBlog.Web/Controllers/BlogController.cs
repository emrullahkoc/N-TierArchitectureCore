using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        BlogContext db = new BlogContext();

        public IActionResult Index()
        {
            IEnumerable<Article> Articles = db.Articles
                  .Where(c => c.Status == true)
                  .ToList();
            return View(Articles);
        }
    }
}
