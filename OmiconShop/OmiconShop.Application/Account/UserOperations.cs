using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Account
{
    public class UserOperations
    {
        public UserAddress FillUserAddressProperties(RegisterViewModel model, User user)
        {
            UserAddress userAddress = new UserAddress()
            {
                Country = model.Country,
                City = model.City,
                Address = model.Address,
                Address2 = model.Address2,
                ZipCode = model.ZipCode,
                UserId = user.Id
            };

            user.UserAddress = userAddress;

            return userAddress;
        }
    }
}
