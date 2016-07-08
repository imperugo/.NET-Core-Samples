using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.aspnet.core.training.ViewModels
{
	public class LoginVM : ModelBase
	{
		public string Username { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }

		public string ReturnUrl { get; set; }
	}
}
