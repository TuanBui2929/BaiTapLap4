using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaiTapLap4.Startup))]
namespace BaiTapLap4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
