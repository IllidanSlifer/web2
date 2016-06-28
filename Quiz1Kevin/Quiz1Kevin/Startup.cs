using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quiz1Kevin.Startup))]
namespace Quiz1Kevin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
