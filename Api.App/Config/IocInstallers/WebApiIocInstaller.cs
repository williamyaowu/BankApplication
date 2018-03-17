using Api.App.Common.Services.Impl;
using Api.App.Common.Services.Interface;
using Api.App.Infrastructure.Persistance.FileDB;
using Api.App.Infrastructure.Persistance.Interface;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Configuration;
using System.Web.Http.Controllers;

namespace Api.App.Config.IocInstallers
{
    public class WebApiIocInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            var subTypeAssembly = GetType().Assembly;
            container.Register(Classes.FromAssembly(subTypeAssembly)
                .BasedOn<IHttpController>()
                .LifestyleTransient());

            container.Register(Classes.FromAssembly(subTypeAssembly)
              .BasedOn<IRepository>()
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            container.Register(Classes.FromAssembly(subTypeAssembly)
                .BasedOn<IMapping>()
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Component.For<IPersistancSession>()
                .UsingFactoryMethod(()=> { return new FileDBSession(ConfigurationManager.AppSettings["LocalTextDBFileName"]); })
                .LifestyleScoped());

            container.Register(Component.For<IConverterManager>()
                .UsingFactoryMethod((con) => {
                    var mappings = con.ResolveAll<IMapping>();
                    return new ConverterManger(mappings);
                })
                .LifestyleSingleton());


        }
    }
}