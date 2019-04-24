using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Account
{
    public class AccountApi
    {
        IUserRepository userRepository;

        public AccountApi(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(RegisterViewModel model)
        {
            var user = userRepository.GetUserByEmail(model.Login);
            FillUserData(model, user);
            userRepository.SaveUser(user);
        }

        void FillUserData(RegisterViewModel model, User user)
        {
            user.UserAddress.Country = model.Country;
            user.UserAddress.City = model.City;
            user.UserAddress.Address = model.Address;
            user.UserAddress.Address2 = model.Address2;
            user.UserAddress.ZipCode = model.ZipCode;
            user.UserAddress.UserId = user.Id;

            user.UserPersonalInformation.UserId = user.Id;
            user.UserPersonalInformation.Name = model.Name;
            user.UserPersonalInformation.Surname = model.Surname;
            user.UserPersonalInformation.PhoneNumber = model.PhoneNumber;
        }
    }
}
