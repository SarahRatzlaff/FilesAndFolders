using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilesAndFolders.Web.Startup))]
namespace FilesAndFolders.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
