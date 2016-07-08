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
using Microsoft.Extensions.Configuration;
using imperugo.aspnet.core.training.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace imperugo.aspnet.core.training
{
	public class Startup
	{
		private readonly IConfigurationRoot configurationRoot;
		private readonly IHostingEnvironment hostingEnvironment;
		private readonly Configuration myConfiguration;

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			this.hostingEnvironment = hostingEnvironment;

			var builder = new ConfigurationBuilder()
				.SetBasePath(this.hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", false, true)
				.AddJsonFile($"appsettings.{this.hostingEnvironment.EnvironmentName}.json", true)
				.AddEnvironmentVariables();


			configurationRoot = builder.Build();
			myConfiguration = new Configuration();
			configurationRoot.Bind(myConfiguration);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var fullDbPath = this.hostingEnvironment.ContentRootPath + "\\" + this.myConfiguration.DbName;

			var connectionString = $"Data Source={fullDbPath}";


			services.AddDbContext<BlogDbContext>(options => options.UseSqlite(connectionString));

			services.AddIdentity<User, IdentityRole>()
					.AddEntityFrameworkStores<BlogDbContext>();

			services.AddMvc();

			services.AddSingleton(this.myConfiguration);

			/*
			 * We need to register the repository implementation into the DI container
			 */
			services.AddSingleton<IBlogConfigurationRepository, BlogConfigurationRepository>();
			services.AddScoped<IBlogPostRepository, Repositories.SqLiteRepositories.BlogPostRepository>();
		}

		public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
		{
			if (this.hostingEnvironment.IsDevelopment())
			{
				loggerFactory.AddDebug(LogLevel.Debug);
				loggerFactory.AddConsole(this.configurationRoot.GetSection("logging"));

				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
				{
					var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
					serviceScope.ServiceProvider.GetService<BlogDbContext>().EnsureSeedData(userManager).Wait();
				}
			}

			//Here a good link https://docs.asp.net/en/latest/fundamentals/environments.html
			if (this.myConfiguration.ShowException)
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentity();

			// Add MVC to the request pipeline
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });
			});
		}
	}
}
