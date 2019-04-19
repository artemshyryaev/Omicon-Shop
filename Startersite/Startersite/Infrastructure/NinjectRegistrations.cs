using Ninject;
using Ninject.Modules;
using OmiconShop.Application.Admin;
using OmiconShop.Application.Admin.Operations;
using Startersite.IManagers;
using Startersite.Managers;
using Startersite.ReplacementTags;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
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
            Bind<IEmailSender>().To<EmailSender>();
            Bind<EmailSettings>().To<EmailSettings>();
            Bind<SmtpClient>().To<SmtpClient>();
            Bind<ReplacementTagsProcessor>().To<ReplacementTagsProcessor>();
            Bind<AdminApi>().To<AdminApi>();
            Bind<UserOperations>().To<UserOperations>();
            Bind<OrderOperations>().To<OrderOperations>();
        }
    }
}