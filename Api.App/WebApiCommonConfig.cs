using Api.App.Config.IocInstallers;
using Api.App.Infrastructure.Api.Dependency;
using System.Web.Http;

namespace Api.App
{
    public class WebApiCommonConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = IoC.Container;

            container.Install(new WebApiIocInstaller());
            container.Install(new BankIocInstaller());

            config.DependencyResolver = new WindsorApiResolver(container);
        }
    }
}