namespace POC_DH.Controllers
{
	using Excel;
	using ViewModels;
	using System.Data;
	using System.Web.Mvc;
	using System.IO;
	using System.Collections.Generic;

	public class DHController : Controller
    {
        // GET: DH
        public ActionResult Index()
        {
			var viewModel = new DashboardViewModel();

			viewModel.Weeks.Add("Week 0");
			viewModel.Weeks.Add("Week 1");
			viewModel.Weeks.Add("Week 2");
			viewModel.Weeks.Add("Week 3");
			viewModel.Weeks.Add("Week 4");

			var filePath = @"c:\dh.xlsx";

			FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read);

			//2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
			IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

			//3. DataSet - The result of each spreadsheet will be created in the result.Tables
			DataSet result = excelReader.AsDataSet();

			//4. DataSet - Create column names from first row
			//excelReader.IsFirstRowAsColumnNames = true;
			//DataSet result = excelReader.AsDataSet();

			if (result != null)
			{
				viewModel.Competitors = new List<CompetitorViewModel>();

				for (int i = 2; i < result.Tables[0].Rows.Count; i++)
				{
					var competitor = new CompetitorViewModel();

					var row = result.Tables[0].Rows[i];

					competitor.Name = row[0].ToString();
					competitor.Activities = int.Parse(row[row.ItemArray.Length - 1].ToString());

					competitor.WeekActivities.Add(0);
					competitor.WeekActivities.Add(competitor.Activities);
					competitor.WeekActivities.Add((competitor.Activities + i));
					competitor.WeekActivities.Add((competitor.Activities + i + i));

					viewModel.Competitors.Add(competitor);
				}

				//foreach (DataRow item in result.Tables[0].Rows)
				//{
				//	var competitor = new CompetitorViewModel();
				//	competitor.Name = item[0].ToString();

				//	competitors.Add(competitor);
				//}
			}


			////5. Data Reader methods
			//while (excelReader.Read())
			//{

			//	var a = excelReader.GetInt32(0);
			//}

			//6. Free resources (IExcelDataReader is IDisposable)
			excelReader.Close();

			return View(viewModel);
        }
    }
}