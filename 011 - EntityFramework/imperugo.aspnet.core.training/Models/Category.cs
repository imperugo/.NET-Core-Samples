using System.Collections.Generic;

namespace imperugo.aspnet.core.training.Models
{
	public class Category : EntityBase
	{
		public string Name { get; set; }
		public List<Post> Posts { get; set; }
	}
}