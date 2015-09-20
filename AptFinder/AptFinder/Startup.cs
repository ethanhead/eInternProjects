using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AptFinder.Startup))]
namespace AptFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
