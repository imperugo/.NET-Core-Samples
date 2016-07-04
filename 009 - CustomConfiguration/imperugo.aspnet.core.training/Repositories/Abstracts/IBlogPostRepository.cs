using System.Collections.Generic;
using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Responses;

namespace imperugo.aspnet.core.training.Repositories.Abstracts
{
	public interface IBlogPostRepository
	{
		PagedResult<BlogPost> GetPosts(int pageIndex, int pageSize);
		BlogPost GetById(string slug);
	}
}