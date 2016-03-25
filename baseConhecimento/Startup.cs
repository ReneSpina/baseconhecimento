using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(baseConhecimento.Startup))]
namespace baseConhecimento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
