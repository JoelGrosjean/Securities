using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prog35142.week11.security.Startup))]
namespace prog35142.week11.security
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
