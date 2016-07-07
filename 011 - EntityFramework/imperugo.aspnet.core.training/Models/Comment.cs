namespace imperugo.aspnet.core.training.Models
{
	public class Comment : EntityBase
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Message { get; set; }
	}
}