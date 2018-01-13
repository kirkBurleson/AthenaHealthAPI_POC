using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AthenaApiPoc.Startup))]
namespace AthenaApiPoc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
