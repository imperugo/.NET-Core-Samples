using System;

namespace imperugo.aspnet.core.training.Models
{
	public abstract class EntityBase
	{
		protected EntityBase()
		{
			this.CreateAt = DateTimeOffset.Now;
		}

		public int Id { get; set; }
		public DateTimeOffset CreateAt { get; set; }
	}
}