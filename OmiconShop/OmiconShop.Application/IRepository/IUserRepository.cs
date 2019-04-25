using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        User GetUserById(int id);

        User ChangeUserEmail(int id, string email);

        void SaveUser(User user);

        void DeleteUserByUserId(int userId);

        void UpdateUser(string email, Action<User> user);
    }
}
