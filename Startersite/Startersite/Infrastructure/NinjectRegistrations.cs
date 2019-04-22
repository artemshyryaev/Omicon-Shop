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
using AdminProductOperations = OmiconShop.Application.Admin.Operations.ProductOperations;
using HomeProductOperations = OmiconShop.Application.Home.Operations.ProductOperations;
using OmiconShop.Application.ReplacementTags;

namespace OmiconShop.WebUI.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<EmailSender>().To<EmailSender>();
            Bind<EmailSettings>().To<EmailSettings>();
            Bind<SmtpClient>().To<SmtpClient>();
            Bind<ReplacementTagsProcessor>().To<ReplacementTagsProcessor>();
            Bind<AdminApi>().To<AdminApi>();
            Bind<AdminOrderOperations>().To<AdminOrderOperations>();
            Bind<AdminProductOperations>().To<AdminProductOperations>();
            Bind<HomeProductOperations>().To<HomeProductOperations>();
            Bind<CheckoutOrderOperations>().To<CheckoutOrderOperations>();
            Bind<BasketApi>().To<BasketApi>();
        }
    }
}