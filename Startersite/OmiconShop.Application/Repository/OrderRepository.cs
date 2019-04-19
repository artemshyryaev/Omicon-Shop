using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using OmiconShop.Persistence;
using Startersite.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Startersite.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetOrderById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Orders.Include(e => e.OrderInformation)
                            .Include(e => e.BasketLine)
                            .Include(e => e.User)
                            .First(e => e.Id == orderId);
            }
        }

        public Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Orders.Include(e => e.OrderInformation)
                            .Include(e => e.BasketLine)
                            .Include(e => e.User)
                            .First(e => e.Id == orderId && e.User.Email == email);
            }
        }

        public void DeclineOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(e => e.Id == orderId);
                order.Status = OrderStatuses.Declined;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void ApproveOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(e => e.Id == orderId);
                order.Status = OrderStatuses.Approved;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.FirstOrDefault(e => e.Id == orderId);

                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void ChangeUserEmailInOrders(int id, string newEmail)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                var dbEntry = context.Orders.Where(e => e.User.Id == id)
                        .Include(e => e.BasketLine)
                        .Include(e => e.OrderInformation)
                        .Include(e => e.User).ToList();

                foreach (var el in dbEntry)
                {
                    el.User.Email = newEmail;

                    context.Entry(el).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}
