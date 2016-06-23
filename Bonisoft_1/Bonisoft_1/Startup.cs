using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bonisoft_1.Startup))]
namespace Bonisoft_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
