﻿namespace imperugo.aspnet.core.training.Models
{
	public class PostTags
	{
		public int PostId { get; set; }
		public int TagId { get; set; }
		public Post Post { get; set; }
		public Tag Tag { get; set; }
	}
}