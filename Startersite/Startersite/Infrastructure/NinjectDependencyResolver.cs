using Ninject;
using Startersite.IManagers;
using Startersite.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Startersite.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IOrderProcessor>().To<OrderProcessor>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAdFile"] ?? "true")
            };

            kernel.Bind<IEmailSender>().To<EmailSender>().WithConstructorArgument("emailSettings", emailSettings);
        }
    }
}