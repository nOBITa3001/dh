namespace POC_DH.ViewModels
{
	using System.Collections.Generic;

	public class CompetitorViewModel
	{
		public string Name { get; set; }
		public List<int> WeekActivities { get; set; }
		public int Activities { get; set; }

		public CompetitorViewModel()
		{
			this.WeekActivities = new List<int>();
		}
	}
}