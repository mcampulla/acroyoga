using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(acroyoga.it.admin.Startup))]
namespace acroyoga.it.admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
