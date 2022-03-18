using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Purchase.System.Startup))]
namespace Purchase.System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
