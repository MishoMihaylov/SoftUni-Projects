using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homemade.Startup))]
namespace Homemade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
