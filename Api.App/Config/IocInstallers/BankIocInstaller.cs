using Api.App.Bank.Services.Impl;
using Api.App.Bank.Services.Interface;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.App.Config.IocInstallers
{
    public class BankIocInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPaymentService>().ImplementedBy<PaymentService>().LifestyleTransient());
        }
    }
}