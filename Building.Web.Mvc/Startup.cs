using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Building.Web.Mvc.Startup))]
namespace Building.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
