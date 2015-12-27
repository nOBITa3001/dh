using System.Web;
using System.Web.Optimization;

namespace BreadcrumbCafe.MVC
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/css-landing").Include(
					  "~/assets/plugins/bootstrap/css/bootstrap.min.css"
					  , "~/assets/css/style.css"
					  , "~/assets/css/headers/header-v6.css"
					  , "~/assets/css/footers/footer-v6.css"
					  , "~/assets/plugins/animate.css"
					  , "~/assets/plugins/line-icons/line-icons.css"
					  , "~/assets/plugins/font-awesome/css/font-awesome.min.css"
					  , "~/assets/plugins/fancybox/source/jquery.fancybox.css"
					  , "~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.css"
					  , "~/assets/plugins/master-slider/masterslider/style/masterslider.css"
					  , "~/assets/plugins/master-slider/masterslider/skins/black-2/style.css"
					  , "~/assets/css/pages/page_one.css"
					  , "~/assets/css/theme-colors/bcc-red.css"
					  , "~/assets/css/footers/footer-v7.css"
					  , "~/assets/css/custom.css"));
			// TODO: Clean
			//<!-- CSS Global Compulsory -->
			//<link rel="stylesheet" href="~/assets/plugins/bootstrap/css/bootstrap.min.css">
			//<link rel="stylesheet" href="~/assets/css/style.css">
			//<!-- CSS Header and Footer -->
			//<link rel="stylesheet" href="~/assets/css/headers/header-v6.css">
			//<link rel="stylesheet" href="~/assets/css/footers/footer-v6.css">
			//<!-- CSS Implementing Plugins -->
			//<link rel="stylesheet" href="~/assets/plugins/animate.css">
			//<link rel="stylesheet" href="~/assets/plugins/line-icons/line-icons.css">
			//<link rel="stylesheet" href="~/assets/plugins/font-awesome/css/font-awesome.min.css">
			//<link rel="stylesheet" href="~/assets/plugins/fancybox/source/jquery.fancybox.css">
			//<link rel="stylesheet" href="~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.css">
			//<link rel="stylesheet" href="~/assets/plugins/master-slider/masterslider/style/masterslider.css">
			//<link rel='stylesheet' href="~/assets/plugins/master-slider/masterslider/skins/black-2/style.css">
			//<!-- CSS Pages Style -->
			//<link rel="stylesheet" href="~/assets/css/pages/page_one.css">
			//<!-- CSS Theme -->
			//<link rel="stylesheet" href="~/assets/css/theme-colors/bcc-red.css" id="style_color">
			//<!-- CSS Footer -->
			//<link rel="stylesheet" href="~/assets/css/footers/footer-v7.css">
			//<!-- CSS Customization -->
			//<link rel="stylesheet" href="~/assets/css/custom.css">

			bundles.Add(new ScriptBundle("~/bundles/js-landing").Include(
					  //"~/assets/plugins/jquery/jquery.min.js"
					  "~/assets/plugins/jquery/jquery-migrate.min.js"
					  , "~/assets/plugins/bootstrap/js/bootstrap.min.js"
					  , "~/assets/plugins/back-to-top.js"
					  , "~/assets/plugins/smoothScroll.js"
					  , "~/assets/plugins/jquery.parallax.js"
					  , "~/assets/plugins/master-slider/masterslider/masterslider.min.js"
					  , "~/assets/plugins/master-slider/masterslider/jquery.easing.min.js"
					  , "~/assets/plugins/counter/waypoints.min.js"
					  , "~/assets/plugins/counter/jquery.counterup.min.js"
					  , "~/assets/plugins/fancybox/source/jquery.fancybox.pack.js"
					  , "~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.js"
					  , "~/assets/js/custom.js"
					  , "~/assets/js/app.js"
					  , "~/assets/js/plugins/fancy-box.js"
					  , "~/assets/js/plugins/owl-carousel.js"
					  , "~/assets/js/plugins/master-slider-fw.js"
					  , "~/assets/js/plugins/revolution-slider.js"));
			// TODO: Clean
			//<!-- JS Global Compulsory -->
			//<script type="text/javascript" src="~/assets/plugins/jquery/jquery.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/jquery/jquery-migrate.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
			//<!-- JS Implementing Plugins -->
			//<script type="text/javascript" src="~/assets/plugins/back-to-top.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/smoothScroll.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/jquery.parallax.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/master-slider/masterslider/masterslider.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/master-slider/masterslider/jquery.easing.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/counter/waypoints.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/counter/jquery.counterup.min.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/fancybox/source/jquery.fancybox.pack.js"></script>
			//<script type="text/javascript" src="~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.js"></script>
			//<!-- JS Customization -->
			//<script type="text/javascript" src="~/assets/js/custom.js"></script>
			//<!-- JS Page Level -->
			//<script type="text/javascript" src="~/assets/js/app.js"></script>
			//<script type="text/javascript" src="~/assets/js/plugins/fancy-box.js"></script>
			//<script type="text/javascript" src="~/assets/js/plugins/owl-carousel.js"></script>
			//<script type="text/javascript" src="~/assets/js/plugins/master-slider-fw.js"></script>
			//<script type="text/javascript" src="~/assets/js/plugins/revolution-slider.js"></script>
		}
	}
}
