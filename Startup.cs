using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SS_Blog.Startup))]
namespace SS_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
