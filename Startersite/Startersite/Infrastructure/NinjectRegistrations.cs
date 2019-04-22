using Ninject.Modules;
using OmiconShop.Application.Admin;
using OmiconShop.Application.Admin.Operations;
using OmiconShop.Application.Basket;
using OmiconShop.Application.Checkout.Operations;
using OmiconShop.Application.IRepository;
using OmiconShop.Application.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;
using AdminOrderOperations = OmiconShop.Application.Admin.Operations.OrderOperations;
using CheckoutOrderOperations = OmiconShop.Application.Checkout.Operations.OrderOperations;

namespace OmiconShop.WebUI.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<EmailSender>().To<EmailSender>();
            Bind<EmailSettings>().To<EmailSettings>();
            Bind<SmtpClient>().To<SmtpClient>();
            //Bind<ReplacementTagsProcessor>().To<ReplacementTagsProcessor>();
            Bind<AdminApi>().To<AdminApi>();
            //Bind<UserOperations>().To<UserOperations>();
            Bind<AdminOrderOperations>().To<AdminOrderOperations>();
            Bind<ProductOperations>().To<ProductOperations>();
            Bind<CheckoutOrderOperations>().To<CheckoutOrderOperations>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<BasketApi>().To<BasketApi>();
        }
    }
}