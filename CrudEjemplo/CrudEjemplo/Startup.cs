using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrudEjemplo.Startup))]
namespace CrudEjemplo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
