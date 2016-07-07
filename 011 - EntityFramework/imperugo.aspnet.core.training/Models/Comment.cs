namespace imperugo.aspnet.core.training.Models
{
	public class Comment : EntityBase
	{
        public Post Post { get; set; }
        public string Email { get; set; }
		public string Name { get; set; }
		public string Message { get; set; }
	}
}