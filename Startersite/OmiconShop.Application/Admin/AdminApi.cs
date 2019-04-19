using OmiconShop.Application.Admin.Operations;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OmiconShop.Application.Admin
{
    public class AdminApi
    {
        UserOperations userOperations;
        OrderOperations orderOperations;

        public AdminApi(UserOperations userOperations, OrderOperations orderOperations)
        {
            this.userOperations = userOperations;
            this.orderOperations = orderOperations;
        }

        public User GetCurrentUserData(string userEmail)
        {
            return userOperations.GetUserByEmail(userEmail);
        }

        public User ChangeUserData(int userId, string userEmail)
        {
            var changedUser = userOperations.ChangeUserEmail(userId, userEmail);
            orderOperations.ChangeUserEmailInOrders(userId, changedUser.Email);

            return changedUser;
        }
    }
}
