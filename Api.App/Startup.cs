using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Castle.Windsor;

[assembly: OwinStartup(typeof(Api.App.Startup))]
namespace Api.App
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.Use<WindsorScopeMiddleware>();

            // token generation
            var config = new HttpConfiguration();

            WebApiCommonConfig.Register(config);
            WebApiConfig.Register(config);
      
            app.UseWebApi(config);
        }
    }

}