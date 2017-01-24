using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project1Todo.Startup))]
namespace Project1Todo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
