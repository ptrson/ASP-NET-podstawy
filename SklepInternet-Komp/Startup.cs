using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SklepInternet_Komp.Startup))]
namespace SklepInternet_Komp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
