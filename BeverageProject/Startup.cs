using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeverageProject.Startup))]
namespace BeverageProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
