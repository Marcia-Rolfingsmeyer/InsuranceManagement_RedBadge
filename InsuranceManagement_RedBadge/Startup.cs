using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsuranceManagement_RedBadge.Startup))]
namespace InsuranceManagement_RedBadge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
