using OmiconShop.Application.Account.ViewModel;
using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public User ChangeUserEmail(int id, string email)
        {
            var user = GetUserById(id);

            using (ShopDBContext context = new ShopDBContext())
            {
                user.Email = email;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }

            return user;
        }

        public void SaveUser(User user)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteUserByUserId(int userId)
        {
            var user = GetUserById(userId);

            using (ShopDBContext context = new ShopDBContext())
            {
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateUser(string email, Action<User> user)
        {
            var _user = GetUserByEmail(email)?? throw new NotImplementedException();

            using (ShopDBContext context = new ShopDBContext())
            {
                context.Users.Attach(_user);
                user(_user);
                context.SaveChanges();
            }
        }
    }
}