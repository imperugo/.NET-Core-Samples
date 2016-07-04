using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using imperugo.aspnet.core.training.Repositories.Responses;

namespace imperugo.aspnet.core.training.Repositories.InMemoryRepositories
{
    public class BlogPostRepository : IBlogPostRepository
	{
		private static readonly ConcurrentBag<BlogPost> inMemoryDb = new ConcurrentBag<BlogPost>();

		public PagedResult<BlogPost> GetPosts(int pageIndex, int pageSize)
		{
			var resultSet = inMemoryDb.OrderBy(x => x.PublishDate).Take(pageSize).Skip(pageIndex).ToList();

			return new PagedResult<BlogPost>(pageIndex, pageSize, resultSet, inMemoryDb.Count);
		}

	    public BlogPost GetById(string slug)
	    {
		    return inMemoryDb.FirstOrDefault(x => x.Slug == slug);
	    }
	}
}
