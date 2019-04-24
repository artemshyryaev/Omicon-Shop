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
        ShopDBContext context;

        public UserRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public User GetUserByEmail(string email)
        {
            using (context)
            {
                return context.Users
                         .Include(x => x.UserAddress)
                         .Include(x => x.UserPersonalInformation)
                         .FirstOrDefault(x => x.Email == email);
            }
        }

        public User GetUserById(int id)
        {
            using (context)
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

            using (context)
            {
                user.Email = email;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }

            return user;
        }

        public void SaveUser(User user)
        {
            using (context)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}