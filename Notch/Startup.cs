using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Notch.Startup))]
namespace Notch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
