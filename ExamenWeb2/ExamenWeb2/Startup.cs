using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenWeb2.Startup))]
namespace ExamenWeb2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
