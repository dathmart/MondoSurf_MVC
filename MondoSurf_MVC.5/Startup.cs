using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MondoSurf_MVC._5.Startup))]
namespace MondoSurf_MVC._5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // the terrible hack
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            ConfigureAuth(app);
        }
    }
}
