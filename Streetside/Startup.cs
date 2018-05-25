using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Streetside.Startup))]
namespace Streetside
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
