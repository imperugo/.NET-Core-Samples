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

namespace imperugo.aspnet.core.training
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			/*
			 * We need to register MVC as a service
			 */
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			/*
			 * We need to configure the routing
			 */
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
