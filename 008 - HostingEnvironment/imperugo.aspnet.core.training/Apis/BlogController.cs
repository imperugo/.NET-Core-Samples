using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace imperugo.aspnet.core.training.Apis
{
	// Good article about routing with aspnet core
	// http://stephenwalther.com/archive/2015/02/07/asp-net-5-deep-dive-routing

	[Route("api/[controller]")]
	public class BlogController : Controller
	{
		private readonly IBlogConfigurationRepository blogConfigurationRepository;

		public BlogController(IBlogConfigurationRepository blogConfigurationRepository)
		{
			this.blogConfigurationRepository = blogConfigurationRepository;
		}

		// api/blog/
		[HttpGet]
		public BlogConfiguration Get()
		{
			return this.blogConfigurationRepository.GetDefaultConfiguration();
		}

		// api/blog/
		[HttpPost]
		public IActionResult Post([FromBody] BlogConfiguration configuration)
		{
			if (configuration == null)
			{
				return BadRequest();
			}

			this.blogConfigurationRepository.UpdateConfiguration(configuration);

			return new EmptyResult();
		}

		[HttpDelete]
		public void DeleteConfiguration()
		{
			// Do whatever you want
		}
	}
}