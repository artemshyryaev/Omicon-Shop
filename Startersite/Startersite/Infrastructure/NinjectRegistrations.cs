using Ninject.Modules;
using OmiconShop.Application.Admin;
using OmiconShop.Application.Admin.Operations;
using OmiconShop.Application.Basket;
using OmiconShop.Application.IRepository;
using OmiconShop.Application.Repository;
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
            //Bind<IEmailSender>().To<EmailSender>();
            //Bind<EmailSettings>().To<EmailSettings>();
            Bind<SmtpClient>().To<SmtpClient>();
            Bind<ReplacementTagsProcessor>().To<ReplacementTagsProcessor>();
            Bind<AdminApi>().To<AdminApi>();
            //Bind<UserOperations>().To<UserOperations>();
            Bind<OrderOperations>().To<OrderOperations>();
            Bind<ProductOperations>().To<ProductOperations>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<BasketApi>().To<BasketApi>();
        }
    }
}