using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleMembership.Startup))]
namespace SampleMembership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
