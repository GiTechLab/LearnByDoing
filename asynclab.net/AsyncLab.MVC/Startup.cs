using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsyncLab.MVC.Startup))]
namespace AsyncLab.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
