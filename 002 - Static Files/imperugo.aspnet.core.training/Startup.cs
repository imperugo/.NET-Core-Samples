using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace imperugo.aspnet.core.training
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, 
										ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			/*
			 * Enable static files
			 */
			// app.UseStaticFiles();

			/*
			 * Enable static files with default document
			 */
			// app.UseFileServer();

			/*
			 *  The default file names are "default.htm", "default.html", "index.htm" and "index.html"
			 *  if you want to change the default document name, you have to force the name
			 * 
			 */

			/*
			var options = new DefaultFilesOptions();
			options.DefaultFileNames.Clear();
			options.DefaultFileNames.Add("mydefault.html");

			app.UseDefaultFiles(options);
			app.UseFileServer();
			*/


			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
