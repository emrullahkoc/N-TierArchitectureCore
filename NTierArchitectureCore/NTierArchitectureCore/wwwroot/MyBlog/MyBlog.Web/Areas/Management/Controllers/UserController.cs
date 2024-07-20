using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers
{
	public class UserController : Controller
	{
		BlogContext db = new BlogContext();
		public IActionResult Index()
		{
			var model = db.Users.ToList();
			return View(model);
		}
		public IActionResult Create()
		{
			ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", null);
			return View();
		}
		[HttpPost]
		public IActionResult Create(User model)
		{
			if (ModelState.IsValid)
			{
				model.Id = Guid.NewGuid();
				model.Status = true;
				model.Deleted = false;
				model.CreatedDate = DateTime.Now;
				model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
				db.Users.Add(model);
				db.SaveChanges();
				return Redirect("Management/User/Index");

			}
			ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", model.RoleId);
			return View(model);
		}

	}
}
