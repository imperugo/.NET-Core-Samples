using imperugo.aspnet.core.training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.aspnet.core.training.Repositories.Abstracts
{
	public interface IBlogConfigurationRepository
	{
		BlogConfiguration GetDefaultConfiguration();
		void UpdateConfiguration(BlogConfiguration configuration);
	}
}
