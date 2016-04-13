using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework3TryItPage.Startup))]
namespace Homework3TryItPage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
