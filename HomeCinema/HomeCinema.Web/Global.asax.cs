namespace HomeCinema.Web
{
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	using System.Web.Http;
	using System.Web.Optimization;

	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			
			//GlobalConfiguration.Configure(WebApiConfig.Register);
			var config = GlobalConfiguration.Configuration;

			AreaRegistration.RegisterAllAreas();
			WebApiConfig.Register(config);
			Bootstrapper.Run();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			GlobalConfiguration.Configuration.EnsureInitialized();
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}