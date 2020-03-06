using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamProjectIAN6.Startup))]
namespace TeamProjectIAN6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
