using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using imperugo.aspnet.core.training.Repositories.InMemoryRepositories;
using imperugo.aspnet.core.training.Repositories.Abstracts;

namespace imperugo.aspnet.core.training
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			/*
			 * We need to register the repository implementation into the DI container
			 */
			services.AddSingleton<IBlogConfigurationRepository, BlogConfigurationRepository>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
