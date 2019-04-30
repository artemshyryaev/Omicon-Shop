using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();

        Order GetOrderById(int orderId);

        Order GetOrderByIdAndCustomerEmail(int orderId, string email);

        void DeclineOrderByAdminAsync(int orderId);

        void ApproveOrderByAdminAsync(int orderId);

        void DeleteOrderAsync(int orderId);

        void ChangeUserEmailInOrdersAsync(int id, string newEmail);

        void AddOrderAsync(Order order, Action addOrderData);
    }
}
