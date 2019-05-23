using OmiconShop.Application.Admin.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Admin.Operations
{
    public class UserOperations
    {
        public UserViewModel CreateUserViewModel(User user)
        {
            var createdUser = new UserViewModel
            {
                Id = user.UserId,
                Email = user?.Email,
                Name = user?.UserPersonalInformation?.Name,
                Surname = user?.UserPersonalInformation?.Surname,
                PhoneNumber = user?.UserPersonalInformation?.PhoneNumber,
                Country = user?.UserAddress?.Country,
                City = user?.UserAddress?.City,
                Address = user?.UserAddress?.Address,
                Address2 = user?.UserAddress?.Address2,
                ZipCode = user?.UserAddress?.ZipCode
            };

            return createdUser;
        }
    }
}
