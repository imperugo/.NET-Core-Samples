using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imperugo.aspnet.core.training.Models;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using imperugo.aspnet.core.training.Repositories.Responses;
using Microsoft.Extensions.Logging;

namespace imperugo.aspnet.core.training.Repositories.SqLiteRepositories
{
    public class BlogPostRepository : IBlogPostRepository
	{
	    private readonly ILogger<BlogPostRepository> logger;
        private readonly BlogDbContext context;

        public BlogPostRepository(BlogDbContext context, ILogger<BlogPostRepository> logger)
	    {
            this.context = context;
		    this.logger = logger;
	    }

	    public PagedResult<Post> GetPosts(int pageIndex, int pageSize)
		{
			this.logger.LogDebug("Retrieving Posts ...");

			var resultSet = context.Posts.OrderBy(x => x.PublishDate).Take(pageSize).Skip(pageIndex).ToList();

			this.logger.LogDebug("Retrieved {0} posts.", resultSet.Count);

			return new PagedResult<Post>(pageIndex, pageSize, resultSet, context.Posts.Count());
		}

	    public Post GetById(string slug)
	    {
		    return context.Posts.FirstOrDefault(x => x.Slug == slug);
	    }

        public async void Add(Post newPost)
        {
            context.Posts.Add(newPost);
            await context.SaveChangesAsync();
        }
    }
}
