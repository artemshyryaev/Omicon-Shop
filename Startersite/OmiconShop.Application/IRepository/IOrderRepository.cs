using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startersite.IRepository
{
    public interface IOrderRepository
    {
        Order GetOrderById(int orderId);

        Order GetOrderByIdAndCustomerEmail(int orderId, string email);

        void DeclineOrderByAdmin(int orderId);

        void ApproveOrderByAdmin(int orderId);

        void DeleteOrder(int orderId);

        void ChangeUserEmailInOrders(int id, string newEmail);
    }
}
