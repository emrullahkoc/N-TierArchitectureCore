using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;
using System.Diagnostics;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        BlogContext db = new BlogContext();
       
        public IActionResult Index() {
            MainPage model = db.MainPages.FirstOrDefault();
            return View(model);
        }
        public IActionResult Contact() {
            Contact model = db.Contacts.FirstOrDefault();
            return View(model);
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View(new ContactMessage());
        }
        [HttpPost]
        public IActionResult ContactUs(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                //baþarýlýysa kaydet
                model.Status = true; //
                model.CreatedDate = DateTime.Now; //Tarih saati yaz
				model.FirstName = model.FirstName.ToUpper();//karakterleri büyük harf yapar
				db.ContactMessage.Add(model); //Veriyi iþle
                db.SaveChanges(); //Veriyi Kaydet
                return RedirectToAction("Index"); // Ýndex sayfasýna git
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult About() {
            About model = db.Abouts.FirstOrDefault();
            return View(model);
        }

        public IActionResult Skills(string? name)
        {
            ViewBag.Name = ""; //
            var model =db.Skill.ToList();
            if (name != null)
            {
                ViewBag.Name = name;
                model = model.Where(c => c.Title.ToLower().Contains(name.ToLower()) || c.Description.ToLower().Contains(name.ToLower())).ToList();
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
