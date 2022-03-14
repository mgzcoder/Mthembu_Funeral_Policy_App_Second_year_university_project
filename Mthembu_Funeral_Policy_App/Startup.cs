using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mthembu_Funeral_Policy_App.Startup))]
namespace Mthembu_Funeral_Policy_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
