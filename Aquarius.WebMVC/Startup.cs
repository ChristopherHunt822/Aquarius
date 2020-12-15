using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aquarius.WebMVC.Startup))]
namespace Aquarius.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
