using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Account.Operations
{
    public class UserOperations
    {  
        public void FillUserAddressProperties(RegisterViewModel model, User user)
        {
            UserAddress userAddress = new UserAddress()
            {
                Country = model.Country,
                City = model.City,
                Address = model.Address,
                Address2 = model.Address2,
                ZipCode = model.ZipCode,
                UserId = user.UserAddressId
            };

            user.UserAddress = userAddress;
        }

        public void FillUserPersonalInformationProperties(RegisterViewModel model, User user)
        {
            UserPersonalInformation userPersonalInformation = new UserPersonalInformation()
            {
                UserId = user.UserId,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber
            };

            user.UserPersonalInformation = userPersonalInformation;
        }
    }
}
