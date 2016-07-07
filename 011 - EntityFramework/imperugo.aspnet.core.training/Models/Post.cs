using System;
using System.Collections.Generic;

namespace imperugo.aspnet.core.training.Models
{
	public class Post : EntityBase
	{
		public string Slug { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public DateTimeOffset PublishDate { get; set; }
		public Category Category { get; set; }
		public List<PostTags> Tags { get; set; }
		//public List<Comment> Comments { get; set; }
	}
}