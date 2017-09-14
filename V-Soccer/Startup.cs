using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(V_Soccer.Startup))]
namespace V_Soccer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
