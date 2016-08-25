using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bonisoft_2.Startup))]
namespace Bonisoft_2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
