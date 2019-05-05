using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OmiconShop.Application.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ContextHelper helper;

        public OrderRepository(ContextHelper helper)
        {
            this.helper = helper;
        }

        public IList<Order> GetAllOrders()
        {
            using (var context = helper.Create())
                return context.Orders
                    .Include(e => e.OrderInformation)
                    .Include(e => e.BasketLine)
                    .Include(e => e.User).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            using (var context = helper.Create())
                return context.Orders.Include(e => e.OrderInformation)
                           .Include(e => e.BasketLine)
                           .Include(e => e.User)
                           .FirstOrDefault(e => e.OrderId == orderId);
        }

        public Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (var context = helper.Create())
                return context.Orders.Include(e => e.OrderInformation)
                            .Include(e => e.BasketLine)
                            .Include(e => e.User)
                            .FirstOrDefault(e => e.OrderId == orderId && e.User.Email == email);
        }

        public async Task DeclineOrderByAdminAsync(int orderId)
        {
            using (var context = helper.Create())
            {
                Order order = context.Orders.First(e => e.OrderId == orderId);
                order.Status = OrderStatuses.Declined;
                context.Entry(order).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task ApproveOrderByAdminAsync(int orderId)
        {
            using (var context = helper.Create())
            {
                Order order = context.Orders.First(e => e.OrderId == orderId);
                order.Status = OrderStatuses.Approved;
                context.Entry(order).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            using (var context = helper.Create())
            {
                Order order = context.Orders.FirstOrDefault(e => e.OrderId == orderId);

                context.Entry(order).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task ChangeUserEmailInOrdersAsync(int id, string newEmail)
        {
            using (var context = helper.Create())
            {
                var dbEntry = context.Orders.Where(e => e.User.UserId == id)
                        .Include(e => e.BasketLine)
                        .Include(e => e.OrderInformation)
                        .Include(e => e.User).ToList();

                foreach (var el in dbEntry)
                {
                    el.User.Email = newEmail;

                    context.Entry(el).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
        }

        public Task<Order> AddOrderAsync(Action<Order> addOrderData)
        {
            using (var context = helper.Create())
            {
                Order order = new Order();

                addOrderData(order);
                var addedOrder = context.Orders.Add(order);
                //context.Entry(order).State = EntityState.Added;
                context.SaveChanges();
                return Task.FromResult(addedOrder);
            }
        }
    }
}
