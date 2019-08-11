using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZipFileUploader.Startup))]
namespace ZipFileUploader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
