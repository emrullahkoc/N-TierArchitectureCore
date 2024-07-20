using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class ArticleController : Controller
    {
        BlogContext db = new BlogContext();

        public IActionResult Index()
        {
            IEnumerable<Article> Articles = db.Articles
                .Where(c => c.Status == true)
                .ToList();
            return View(Articles);
        }
        public IActionResult Details(int id)
        {
            Article model = db.Articles.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Article/Index");
            }
            return View(model);
        }
		
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Article model)
		{
			if (ModelState.IsValid)
			{
				//başarılıysa kaydet
				model.Status = true; //
				model.UpdatedDate = null;
				model.CreatedDate = DateTime.Now;
                db.Articles.Add(model); //Veriyi işle
				db.SaveChanges(); //Veriyi Kaydet
				return Redirect("/Management/Article/Index"); // İndex sayfasına git
			}

			return View(model);
		}
		public IActionResult Edit(int id)
		{
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Article model)
		{
			if (ModelState.IsValid)
			{
				Article? editModel = db.Articles.Find(model.Id);
				if (editModel == null)
				{
					return Redirect("/Management/Article/Index");
				}
				editModel.Title = model.Title;
				editModel.Description = model.Description;
				editModel.Author = model.Author;
				editModel.Subject = model.Subject;
				editModel.UpdatedDate = DateTime.Now;
				db.SaveChanges();
				return Redirect("/Management/Article/Index");
			}
			return View(model);

		}
		public IActionResult Delete(int id)
		{
			Article model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			Article? model = db.Articles.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Article/Index");
			}
			model.Status = false; //Statü değiştirmek için
			db.SaveChanges(); //Statü değiştirmek için

			/* Tamamen silmek için
			db.Skill.Remove(model);
			db.SaveChanges();
			*/

			return Redirect("/Management/Article/Index");
		}
	}
}
