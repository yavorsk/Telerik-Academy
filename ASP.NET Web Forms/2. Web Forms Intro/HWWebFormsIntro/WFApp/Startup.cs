using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WFApp.Startup))]
namespace WFApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
