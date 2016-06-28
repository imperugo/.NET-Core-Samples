using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imperugo.aspnet.core.training.Models;
using System.Collections.Concurrent;
using imperugo.aspnet.core.training.Repositories.Abstracts;

namespace imperugo.aspnet.core.training.Repositories.InMemoryRepositories
{
	public class BlogConfigurationRepository: IBlogConfigurationRepository
	{
		private static ConcurrentBag<BlogConfiguration> inMemoryDb = new ConcurrentBag<BlogConfiguration>();

		static BlogConfigurationRepository ()
		{
			var conf = new BlogConfiguration() {
				Author = "Ugo Lattanzi",
				Description = "imperugo's blog",
				Title = "This is the title of my blog engine",
				Tags = new[] { ".NET", ".NET Core", "NodeJs" },
				SiteUri = new Uri("http://www.tostring.it"),
				TwitterAccount = "@imperugo"
			};

			inMemoryDb.Add(conf);
		}

		public BlogConfiguration GetDefaultConfiguration() {
			return inMemoryDb.FirstOrDefault();
		}
	}
}
