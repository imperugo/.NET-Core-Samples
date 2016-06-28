using imperugo.aspnet.core.training.Repositories;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace imperugo.aspnet.core.training.Controllers
{
	public class HomeController : Controller
	{
		private IBlogConfigurationRepository blogConfigurationRepository;

		public HomeController(IBlogConfigurationRepository blogConfigurationRepository) {
			this.blogConfigurationRepository = blogConfigurationRepository;
		}

		public IActionResult Index()
		{
			var model = this.blogConfigurationRepository.GetDefaultConfiguration();
			return View(model);
		}
	}
}
