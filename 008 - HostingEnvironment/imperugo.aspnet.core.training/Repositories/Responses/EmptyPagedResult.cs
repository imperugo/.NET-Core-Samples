using System.Collections.Generic;

namespace imperugo.aspnet.core.training.Repositories.Responses
{
	/// <summary>
	/// 	The implementation of <see cref="IPagedResult{T}" /> used for empty result;
	/// </summary>
	/// <typeparam name="T"> </typeparam>
	public class EmptyPagedResult<T> : PagedResult<T>
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref="EmptyPagedResult{T}" /> class.
		/// </summary>
		/// <param name="pageIndex"> Index of the page. </param>
		/// <param name="pageSize"> Size of the page. </param>
		public EmptyPagedResult(int pageIndex, int pageSize)
			: base(pageIndex, pageSize, new List<T>(), 0)
		{
		}
	}
}