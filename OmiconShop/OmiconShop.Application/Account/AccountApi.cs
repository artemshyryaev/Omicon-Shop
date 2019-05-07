using OmiconShop.Application.Account.Operations;
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
    public delegate void UpdateUser(RegisterViewModel model, User user);
    public class AccountApi
    {
        IUserRepository userRepository;
        UserOperations userOperations;

        public AccountApi(IUserRepository userRepository, UserOperations userOperations)
        {
            this.userRepository = userRepository;
            this.userOperations = userOperations;
        }

        public async Task UpdateUserAsync(RegisterViewModel model)
        {
            await userRepository.UpdateUserAsync(model.Login, (user) =>
            {
                userOperations.FillUserAddressProperties(model, user);
                userOperations.FillUserPersonalInformationProperties(model, user);
            });
        }
    }
}
