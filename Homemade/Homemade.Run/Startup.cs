using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homemade.Run.Startup))]
namespace Homemade.Run
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
