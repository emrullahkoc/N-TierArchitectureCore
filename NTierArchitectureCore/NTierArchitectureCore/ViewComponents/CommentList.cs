using Microsoft.AspNetCore.Mvc;

namespace NTierArchitectureCore.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
