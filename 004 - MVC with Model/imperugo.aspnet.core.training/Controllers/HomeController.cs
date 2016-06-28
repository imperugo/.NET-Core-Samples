using imperugo.aspnet.core.training.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace imperugo.aspnet.core.training.Controllers
{
	public class HomeController : Controller
	{
		private BlogConfigurationRepository blogConfigurationRepository;

		public HomeController() {
			this.blogConfigurationRepository = new BlogConfigurationRepository();
		}

		public IActionResult Index()
		{
			var model = this.blogConfigurationRepository.GetDefaultConfiguration();
			return View(model);
		}
	}
}
