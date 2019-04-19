using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using Startersite.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Startersite.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Users.FirstOrDefault(x => x.Email == email);
            }
        }

        public User GetUserById(int id)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
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
    }
}