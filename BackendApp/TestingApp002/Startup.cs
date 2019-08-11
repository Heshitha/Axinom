using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingApp002.Startup))]
namespace TestingApp002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
