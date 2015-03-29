using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnoWeb.Startup))]
namespace OnoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
