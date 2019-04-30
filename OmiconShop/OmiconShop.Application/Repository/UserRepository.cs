using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OmiconShop.Application.IRepository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Users
                         .Include(x => x.UserAddress)
                         .Include(x => x.UserPersonalInformation)
                         .FirstOrDefault(x => x.Email == email);
            }
        }

        public User GetUserById(int id)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Users
                    .Include(x => x.UserAddress)
                    .Include(x => x.UserPersonalInformation)
                    .FirstOrDefault(x => x.UserId == id);
            }
        }

        public User ChangeUserEmail(int id, string newEmail)
        {
            var user = GetUserById(id);
            user.Email = newEmail;
            Task.Run(() => ModifyUserEmailAsync(user));

            return user;
        }

        private async void ModifyUserEmailAsync(User user)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async void UpdateUserAsync(string email, Action<User> user)
        {
            var _user = GetUserByEmail(email)?? throw new NotImplementedException();

            using (ShopDBContext context = new ShopDBContext())
            {
                context.Users.Attach(_user);
                user(_user);
                await context.SaveChangesAsync();
            }
        }
    }
}