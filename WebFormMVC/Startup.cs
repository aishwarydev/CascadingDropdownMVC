using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormMVC.Startup))]
namespace WebFormMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
