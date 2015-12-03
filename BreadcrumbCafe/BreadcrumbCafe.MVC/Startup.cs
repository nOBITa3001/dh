using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BreadcrumbCafe.MVC.Startup))]
namespace BreadcrumbCafe.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
