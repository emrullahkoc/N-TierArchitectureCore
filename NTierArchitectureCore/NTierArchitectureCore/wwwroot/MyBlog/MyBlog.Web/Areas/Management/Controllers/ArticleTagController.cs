using EK.Helper.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class ArticleTagController : Controller
    {
        BlogContext db = new BlogContext();
        public IActionResult Index()
        {
            IEnumerable<ArticleTag> ArticleTag = db.ArticleTag.Include("Article").Include("Tag")
            .ToList();
            return View(ArticleTag);
        }
        public IActionResult Details(int id)
        {
            ArticleTag model = db.ArticleTag.Find(id);
            if (model == null)
            {
                return Redirect("/Management/ArticleTag/Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", null);
            ViewBag.TagId = new SelectList(db.Tag, "Id", "Name", null);

            return View(new ArticleTag());
        }
        [HttpPost]
        public IActionResult Create(ArticleTag model)
        {
            if (ModelState.IsValid)
            {
                db.ArticleTag.Add(model); //Veriyi işle
                db.SaveChanges(); //Veriyi Kaydet
                return Redirect("/Management/ArticleTag/Index"); // İndex sayfasına git
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "Id", "Title", model.ArticleId);
            ViewBag.TagId = new SelectList(db.Tag, "Id", "Title", model.TagId);

            return View(model);
        }
        [Route("/Management/ArticleTag/Delete/{articleId}/{tagId}")]
        public IActionResult Delete(int articleId, int tagId)
        {
            ArticleTag? model = db.ArticleTag.Include("Article").Include("Tag").FirstOrDefault(x => x.ArticleId == articleId && x.TagId == tagId);
            if (model == null)
            {
                return Redirect("/Management/ArticleTag/Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete"), Route("/Management/ArticleTag/Delete/{articleId}/{tagId}")]
        public IActionResult DeleteConfirmed(int articleId, int tagId)
        {
            ArticleTag? model = db.ArticleTag.Include("Article").Include("Tag").FirstOrDefault(x => x.ArticleId == articleId && x.TagId == tagId);
            if (model == null)
            {
                return Redirect("/Management/ArticleTag/Index");
            }
            db.ArticleTag.Remove(model);
            db.SaveChanges(); //Statü değiştirmek için

            /* Tamamen silmek için
            db.ArticleTag.Remove(model);
            db.SaveChanges();
            */

            return Redirect("/Management/ArticleTag/Index");
        }
    }
}