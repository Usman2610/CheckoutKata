using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckoutKata.Startup))]
namespace CheckoutKata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
