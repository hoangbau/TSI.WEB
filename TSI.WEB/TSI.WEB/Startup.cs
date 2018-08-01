using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSI.WEB.Startup))]
namespace TSI.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
