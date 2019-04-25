using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
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
            userRepository.UpdateUser(model.Login, (user)=> FillUserData(model, user));
        }

        void FillUserData(RegisterViewModel model, User user)
        {

            UserPersonalInformation userPersonalInformation = new UserPersonalInformation()
            {
                UserId = user.Id,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber
            };

            user.UserPersonalInformation = userPersonalInformation;
        }
    }
}
