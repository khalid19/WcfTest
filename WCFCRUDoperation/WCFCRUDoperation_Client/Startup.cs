using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCFCRUDoperation_Client.Startup))]
namespace WCFCRUDoperation_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
