using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LojaDeCarros.Startup))]
namespace LojaDeCarros
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
