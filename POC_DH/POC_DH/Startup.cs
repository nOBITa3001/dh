using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POC_DH.Startup))]
namespace POC_DH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
