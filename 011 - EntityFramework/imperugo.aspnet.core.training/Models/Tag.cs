using System.Collections.Generic;

namespace imperugo.aspnet.core.training.Models
{
	public class Tag : EntityBase
	{
		public string Name { get; set; }
		public List<PostTags> Posts { get; set; }
	}
}