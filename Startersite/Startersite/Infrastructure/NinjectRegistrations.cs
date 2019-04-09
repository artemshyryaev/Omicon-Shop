using Ninject;
using Ninject.Modules;
using Startersite.IManagers;
using Startersite.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Startersite.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IOrderProcessor>().To<OrderProcessor>();
            Bind<IEmailSender>().To<EmailSender>().WithConstructorArgument("emailSettings", new EmailSettings());
        }
    }
}