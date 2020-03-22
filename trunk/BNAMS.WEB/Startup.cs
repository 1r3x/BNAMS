using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SR.Startup))]
namespace SR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
