using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TopNews.Startup))]
namespace TopNews
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
