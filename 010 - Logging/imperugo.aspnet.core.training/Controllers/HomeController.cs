using System;
using imperugo.aspnet.core.training.Repositories;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace imperugo.aspnet.core.training.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBlogConfigurationRepository blogConfigurationRepository;

		public HomeController(IBlogConfigurationRepository blogConfigurationRepository) {
			this.blogConfigurationRepository = blogConfigurationRepository;
		}

		public IActionResult Index()
		{
			var model = this.blogConfigurationRepository.GetDefaultConfiguration();
			return View(model);
		}

		public void Throw()
		{
			int.Parse("this string is not a number so, an Exception should be throw");
		}
	}
}
