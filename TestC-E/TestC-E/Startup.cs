using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestC_E.Startup))]
namespace TestC_E
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
