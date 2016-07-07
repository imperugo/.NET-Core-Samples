using System;
using imperugo.aspnet.core.training.Repositories;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using imperugo.aspnet.core.training.ViewModels;
using imperugo.aspnet.core.training.Models;
using Microsoft.AspNetCore.Authorization;

namespace imperugo.aspnet.core.training.Controllers
{
    [Authorize]
    public class HomeController : Controller
	{
		private readonly IBlogConfigurationRepository blogConfigurationRepository;
        private IBlogPostRepository blogPostRepository;

        public HomeController(IBlogConfigurationRepository blogConfigurationRepository, 
            IBlogPostRepository blogPostRepository) {
			this.blogConfigurationRepository = blogConfigurationRepository;
            this.blogPostRepository = blogPostRepository;
        }

        [AllowAnonymous]
		public IActionResult Index()
		{
			var model = this.blogConfigurationRepository.GetDefaultConfiguration();
			return View(model);
		}

        [AllowAnonymous]
        public IActionResult List()
        {
            var model = this.blogPostRepository.GetPosts(0, 10);
            return View(model);
        }

        [AllowAnonymous]
        public void Throw()
		{
			int.Parse("this string is not a number so, an Exception should be throw");
		}

        [HttpGet]
        public ViewResult Create()
        {
            return View(new PostEditVM());
        }

        [HttpPost]
        public IActionResult Create(PostEditVM model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();
                post.Slug = model.Slug;
                post.Title = model.Title;
                post.Abstract = model.Abstract;
                post.Body = model.Body;
                post.PublishDate = model.PublishDate;
                this.blogPostRepository.Add(post);

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
