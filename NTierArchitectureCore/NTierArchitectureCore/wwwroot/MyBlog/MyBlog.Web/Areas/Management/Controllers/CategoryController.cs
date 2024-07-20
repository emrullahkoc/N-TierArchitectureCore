﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;
using MyBlog.Web.Utils;

namespace MyBlog.Web.Areas.Management.Controllers;

[Area("Management")]
public class CategoryController : Controller
{
	BlogContext db = new BlogContext();
	private readonly IWebHostEnvironment _hostEnvironment;
	public CategoryController(IWebHostEnvironment hostEnvironment)
	{
		_hostEnvironment = hostEnvironment;
	}

	public IActionResult Index()
	{
		var model = db.Categories.ToList();
		ViewBag.Say = model.Count();
		return View(model);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(Category model, IFormFile? img)
	{
		if (ModelState.IsValid)
		{
			if (img != null)
			{
				model.ImageUrl =
					await ImageUploader.UploadImageAsync(_hostEnvironment, img);
			}
			model.Status = true;
			model.CreatedDate = DateTime.Now;
			db.Categories.Add(model);
			db.SaveChanges();
			return Redirect("/Management/Category/Index");
		}
		return View(model);
	}
}
