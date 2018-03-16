using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS01.Startup))]
namespace VS01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
