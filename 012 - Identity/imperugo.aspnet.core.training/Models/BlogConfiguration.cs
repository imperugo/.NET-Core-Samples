using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.aspnet.core.training.Models
{
	public class BlogConfiguration
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string[] Tags { get; set; }
		public string Author { get; set; }
		public Uri SiteUri { get; set; }
		public string TwitterAccount { get; set; }

	}
}
