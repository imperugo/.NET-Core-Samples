using System;

namespace imperugo.aspnet.core.training.Models
{
	public class BlogPost
	{
		public string Slug { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public DateTimeOffset PublishDate { get; set; }
		public string[] Tags { get; set; }
		public string Category { get; set; }
	}
}