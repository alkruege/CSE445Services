using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSE445Homework3.Startup))]
namespace CSE445Homework3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
