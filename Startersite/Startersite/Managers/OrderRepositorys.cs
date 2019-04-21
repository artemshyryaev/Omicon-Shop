using Startersite.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using OmiconShop.Domain.Enumerations;

namespace Startersite.Managers
{
    public class OrderRepositorys : IOrderRepositorys
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }
    }
}