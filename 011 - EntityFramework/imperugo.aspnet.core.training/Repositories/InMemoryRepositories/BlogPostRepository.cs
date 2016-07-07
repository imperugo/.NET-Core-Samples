using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using imperugo.aspnet.core.training.Repositories.Responses;
using Microsoft.Extensions.Logging;

namespace imperugo.aspnet.core.training.Repositories.InMemoryRepositories
{
    public class BlogPostRepository : IBlogPostRepository
	{
		private static readonly ConcurrentBag<Post> inMemoryDb = new ConcurrentBag<Post>();
	    private readonly ILogger<BlogPostRepository> logger;

	    public BlogPostRepository(ILogger<BlogPostRepository> logger)
	    {
		    this.logger = logger;
	    }

	    public PagedResult<Post> GetPosts(int pageIndex, int pageSize)
		{
			this.logger.LogDebug("Retrieving Posts ...");

			var resultSet = inMemoryDb.OrderBy(x => x.PublishDate).Take(pageSize).Skip(pageIndex).ToList();

			this.logger.LogDebug("Retrieved {0} posts.", resultSet.Count);

			return new PagedResult<Post>(pageIndex, pageSize, resultSet, inMemoryDb.Count);
		}

	    public Post GetById(string slug)
	    {
		    return inMemoryDb.FirstOrDefault(x => x.Slug == slug);
	    }
	}
}
