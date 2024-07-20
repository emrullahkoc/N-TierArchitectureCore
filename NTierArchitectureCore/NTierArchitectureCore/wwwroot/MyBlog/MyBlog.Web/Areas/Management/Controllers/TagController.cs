using EK.Helper.Utils;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class TagController : Controller
    {
        BlogContext db = new BlogContext();
        public IActionResult Index()
        {
            IEnumerable<Tag> Tag = db.Tag
                .Where(c => c.Status == true)
                .ToList();
            return View(Tag);
        }
        public IActionResult Details(int id)
        {
            Tag model = db.Tag.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Tag/Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new Tag());
        }
        [HttpPost]
        public IActionResult Create(Tag model)
        {
            if (ModelState.IsValid)
            {
                //başarılıysa kaydet
                model.Status = true; //
                model.Name = model.Name.ToUpper();//karakterleri büyük harf yapar
                db.Tag.Add(model); //Veriyi işle
                db.SaveChanges(); //Veriyi Kaydet

                return Redirect("/Management/Tag/Index"); // İndex sayfasına git
            }

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            Tag? model = db.Tag.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Tag/Index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Tag model)
        {
            if (ModelState.IsValid)
            {
                Tag? editModel = db.Tag.Find(model.Id);
                if (editModel == null)
                {
                    return Redirect("/Management/Tag/Index");
                }
                editModel.Status = true;
                editModel.Name = model.Name.ToUpper();
                db.SaveChanges();
                return Redirect("/Management/Tag/Index");
            }
            return View(model);

        }
        public IActionResult Delete(int id)
        {
            Tag model = db.Tag.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Tag/Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Tag? model = db.Tag.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Tag/Index");
            }
            model.Status = false; //Statü değiştirmek için
            db.SaveChanges(); //Statü değiştirmek için

            /* Tamamen silmek için
            db.Tag.Remove(model);
            db.SaveChanges();
            */

            return Redirect("/Management/Tag/Index");
        }
    }

}
