using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using OmiconShop.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context;

        public OrderRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAllOrders() => context.Orders
                    .Include(e => e.OrderInformation)
                    .Include(e => e.BasketLine)
                    .Include(e => e.User);

        public Order GetOrderById(int orderId)
        {
            using (context)
            {
                return context.Orders.Include(e => e.OrderInformation)
                            .Include(e => e.BasketLine)
                            .Include(e => e.User)
                            .First(e => e.OrderId == orderId);
            }
        }

        public Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (context)
            {
                return context.Orders.Include(e => e.OrderInformation)
                            .Include(e => e.BasketLine)
                            .Include(e => e.User)
                            .First(e => e.OrderId == orderId && e.User.Email == email);
            }
        }

        public void DeclineOrderByAdmin(int orderId)
        {
            using (context)
            {
                Order order = context.Orders.First(e => e.OrderId == orderId);
                order.Status = OrderStatuses.Declined;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void ApproveOrderByAdmin(int orderId)
        {
            using (context)
            {
                Order order = context.Orders.First(e => e.OrderId == orderId);
                order.Status = OrderStatuses.Approved;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (context)
            {
                Order order = context.Orders.FirstOrDefault(e => e.OrderId == orderId);

                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void ChangeUserEmailInOrders(int id, string newEmail)
        {
            using (context)
            {
                var dbEntry = context.Orders.Where(e => e.User.UserId == id)
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

        public void AddOrder(Order order, Action addOrderData)
        {
            using (context)
            {
                addOrderData();
                context.Entry(order).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
