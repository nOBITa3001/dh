namespace HomeCinema.Web.Infrastructure.Core
{
	using System.Collections.Generic;
	using System.Linq;

	public class PaginationSet<T>
	{
		public int Page { get; set; }

		public int Count
		{
			get
			{
				return (this.Items != null)
						? this.Items.Count()
						: 0;
			}
		}

		public int TotalPages { get; set; }
		public int TotalCount { get; set; }

		public IEnumerable<T> Items { get; set; }
	}
}