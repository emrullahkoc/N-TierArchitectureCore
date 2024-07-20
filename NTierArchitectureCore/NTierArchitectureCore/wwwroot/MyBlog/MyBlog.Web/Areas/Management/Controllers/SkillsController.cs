using EK.Helper.Utils;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;
using MyBlog.Web.Utils;
using System.Runtime.Intrinsics.Arm;


namespace MyBlog.Web.Areas.Management.Controllers
{
	[Area("Management")]
	public class SkillsController : Controller
	{
		BlogContext db = new BlogContext();
		public IActionResult Index()
		{
			IEnumerable<Skill> skills = db.Skill
				.Where(c => c.Status == true)
				.ToList();
			return View(skills);
		}
		public IActionResult Details(int id) 
		{
			Skill model = db.Skill.Find(id);
			if (model==null)
			{
				return Redirect("/Management/Skill/Index");
			}
			return View(model); 
		}

		[HttpGet]
		public IActionResult Create()
		{

			return View(new Skill());
		}
		[HttpPost]
		public IActionResult Create(Skill model)
		{
			if (ModelState.IsValid)
			{
				//başarılıysa kaydet
				model.Status = true; //
				model.Title = model.Title.ToUpper();//karakterleri büyük harf yapar
				db.Skill.Add(model); //Veriyi işle
				db.SaveChanges(); //Veriyi Kaydet

				//mail göndermek için
				var mailList = new List<String>() { 
				"erkann.fatma@gmail.com"
				};
                
                    MailSender.Send(mailList, "Yetenek Eklendi", $"Blog sitenize yeni bir yetenek eklendi </br> {model.Title}");

                return Redirect("/Management/Skills/Index"); // İndex sayfasına git
			}

			return View(model);
		}
		public IActionResult Edit(int id)
		{
			Skill? model = db.Skill.Find(id);
			if (model==null)
			{
				return Redirect("/Management/Skills/Index");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Skill model)
		{
			if (ModelState.IsValid)
			{
				Skill? editModel = db.Skill.Find(model.Id);
				if (editModel == null)
				{
					return Redirect("/Management/Skills/Index");
				}
				editModel.Status = true;
				editModel.Title = model.Title.ToUpper();
				editModel.Score = model.Score;
				editModel.Description = model.Description;
				db.SaveChanges();
				return Redirect("/Management/Skills/Index");
			}
			return View(model);

		}
		public IActionResult Delete(int id)
		{
			Skill model = db.Skill.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Skills/Index");
			}
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			Skill? model = db.Skill.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Skills/Index");
			}
			model.Status = false; //Statü değiştirmek için
			db.SaveChanges(); //Statü değiştirmek için

			/* Tamamen silmek için
			db.Skill.Remove(model);
			db.SaveChanges();
			*/

			return Redirect("/Management/Skills/Index");
		}

		[Route("/Management/Skills/DeleteWithJs/{id}")] // Uzantı Adları Burada Belirtiliyor
		[HttpPost]
		public JsonResult DeleteWithJs(int id)
		{
            Skill? model = db.Skill.Find(id);
            if (model == null)
            {
                return Json("Böyle Birşey Bulunamadı");
            }
            model.Status = false; //Statü değiştirmek için
            db.SaveChanges(); //Statü değiştirmek için

            /* Tamamen silmek için
			db.Skill.Remove(model);
			db.SaveChanges();
			*/

            return Json("Silindi");
        }
	}
}
