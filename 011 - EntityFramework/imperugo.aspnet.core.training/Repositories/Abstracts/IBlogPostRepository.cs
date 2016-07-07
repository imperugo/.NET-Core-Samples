using System.Collections.Generic;
using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Responses;

namespace imperugo.aspnet.core.training.Repositories.Abstracts
{
	public interface IBlogPostRepository
	{
		PagedResult<Post> GetPosts(int pageIndex, int pageSize);
		Post GetById(string slug);
	}
}