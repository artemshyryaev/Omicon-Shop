using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public interface IOrderRepository
    {
        IList<Order> GetAllOrders();

        Order GetOrderById(int orderId);

        Order GetOrderByIdAndCustomerEmail(int orderId, string email);

        Task DeclineOrderByAdminAsync(int orderId);

        Task ApproveOrderByAdminAsync(int orderId);

        Task DeleteOrderAsync(int orderId);

        Task ChangeUserEmailInOrdersAsync(int id, string newEmail);

        Task<Order> AddOrderAsync( Action<Order> addOrderData);
    }
}
