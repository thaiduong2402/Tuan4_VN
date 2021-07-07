using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tuan4_VN.Startup))]
namespace Tuan4_VN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
