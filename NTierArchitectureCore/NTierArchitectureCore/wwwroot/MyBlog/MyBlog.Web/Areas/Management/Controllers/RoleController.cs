using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace MyBlog.Web.Areas.Management.Controllers

{
    [Area("Management")]
    public class RoleController : Controller
    {
        BlogContext db=new BlogContext();
        public IActionResult Index()
        {
            var model =db.Roles.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role model) 
        {
            if(ModelState.IsValid)
            {
                model.Status = true;
                model.CreatedDate = DateTime.Now;
                db.Roles.Add(model);
                db.SaveChanges();
                return Redirect("/Management/Role/Index");
            }
            return View(model);
        }
    }
}
