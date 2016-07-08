using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using imperugo.aspnet.core.training.Repositories.Abstracts;
using imperugo.aspnet.core.training.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace imperugo.aspnet.core.training.Filters
{
    public class ModelBaseActionFilter : IActionFilter
    {
		private readonly IBlogConfigurationRepository blogConfigurationRepository;

	    public ModelBaseActionFilter(IBlogConfigurationRepository blogConfigurationRepository)
	    {
		    this.blogConfigurationRepository = blogConfigurationRepository;
	    }

	    public void OnActionExecuting(ActionExecutingContext context)
		{
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			var result = context.Result as ViewResult;

			if (result == null)
			{
				// The controller action didn't return a view result 
				// => no need to continue any further
				return;
			}

			var model = result.Model as ModelBase;
			if (model == null)
			{
				// there's no model or the model was not of the expected type 
				// => no need to continue any further
				return;
			}

			model.BlogConfiguration = this.blogConfigurationRepository.GetDefaultConfiguration();
		}
	}
}
