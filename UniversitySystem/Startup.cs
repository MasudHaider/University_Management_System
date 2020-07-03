using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversitySystem.Startup))]
namespace UniversitySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
