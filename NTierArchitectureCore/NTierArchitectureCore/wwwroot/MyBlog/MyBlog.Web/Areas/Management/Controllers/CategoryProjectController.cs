using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
    [Area("Management")]

    public class CategoryProjectController : Controller
    {
        BlogContext db = new BlogContext();
        public IActionResult Index()
        {
            IEnumerable<CategoryProject> CategoryProject = db.CategoryProject.Include("Category").Include("Project")
            .ToList();
            return View(CategoryProject);
        }
        public IActionResult Details(int id)
        {
            CategoryProject model = db.CategoryProject.Find(id);
            if (model == null)
            {
                return Redirect("/Management/CategoryProject/Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", null);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", null);

            return View(new CategoryProject());
        }
        [HttpPost]
        public IActionResult Create(CategoryProject model)
        {
            if (ModelState.IsValid)
            {
                db.CategoryProject.Add(model); //Veriyi işle
                db.SaveChanges(); //Veriyi Kaydet
                return Redirect("/Management/CategoryProject/Index"); // İndex sayfasına git
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Title", model.CategoryId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", model.ProjectId);

            return View(model);
        }
        [Route("/Management/CategoryProject/Delete/{CategoryId}/{ProjectId}")]
        public IActionResult Delete(int CategoryId, int ProjectId)
        {
            CategoryProject? model = db.CategoryProject.Include("Category").Include("Project").FirstOrDefault(x => x.CategoryId == CategoryId && x.ProjectId == ProjectId);
            if (model == null)
            {
                return Redirect("/Management/CategoryProject/Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete"), Route("/Management/CategoryProject/Delete/{CategoryId}/{ProjectId}")]
        public IActionResult DeleteConfirmed(int CategoryId, int ProjectId)
        {
            CategoryProject? model = db.CategoryProject.Include("Category").Include("Project").FirstOrDefault(x => x.CategoryId == CategoryId && x.ProjectId == ProjectId);
            if (model == null)
            {
                return Redirect("/Management/CategoryProject/Index");
            }
            db.CategoryProject.Remove(model);
            db.SaveChanges(); //Statü değiştirmek için

            /* Tamamen silmek için
            db.CategoryProject.Remove(model);
            db.SaveChanges();
            */

            return Redirect("/Management/CategoryProject/Index");
        }

    }
}
