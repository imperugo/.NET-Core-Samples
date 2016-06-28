using Microsoft.AspNetCore.Mvc;

namespace imperugo.aspnet.core.training.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Title = "This is my new super MVC application";
			return View();
		}
	}
}
