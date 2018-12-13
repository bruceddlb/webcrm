using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QSDMS.WebSite.Web.Startup))]
namespace QSDMS.WebSite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
