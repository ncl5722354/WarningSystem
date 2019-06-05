using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newwarnsystem.Startup))]
namespace newwarnsystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
