using Microsoft.AspNetCore.Mvc;

namespace imperugo.aspnet.core.training.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return Content("Pagina in costruzione");
		}
	}
}