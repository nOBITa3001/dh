namespace POC_DH.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

	public class DashboardViewModel
	{
		public int Registers
		{
			get
			{
				if (this.Competitors != null)
				{
					return this.Competitors.Count;
				}
				else
				{
					return 0;
				}
			}
		}

		public int Activities
		{
			get
			{
				var result = 0;

				if (this.Competitors != null)
				{
					this.Competitors.ForEach(x => result += x.Activities);
				}

				return result;
			}
		}

		public int DaysProgress
		{
			get
			{
				var startDate = new DateTime(2015, 09, 01);
				var result = DateTime.Today.Subtract(startDate).Days;
				var endDate = new DateTime(2015, 10, 31);
				var maxDays = endDate.Subtract(startDate).Days;

				if (result <= maxDays)
				{
					return result;
				}
				else
				{
					return maxDays;
				}

			}
		}

		public int DaysLeft
		{
			get
			{
				var endDate = new DateTime(2015, 10, 31);
				var result = endDate.Subtract(DateTime.Today).Days;

				if (result > 1)
				{
					return result;
				}
				else
				{
					return 0;
				}
			}
		}

		public CompetitorViewModel FirstRanking
		{
			get
			{
				if (this.Competitors != null)
				{
					return this.Competitors.OrderByDescending(x => x.Activities).First();
				}

				return null;
			}
		}

		public List<CompetitorViewModel> Competitors { get; set; }
	}
}