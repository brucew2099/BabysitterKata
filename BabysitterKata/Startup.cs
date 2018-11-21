using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BabysitterKata.Startup))]
namespace BabysitterKata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
