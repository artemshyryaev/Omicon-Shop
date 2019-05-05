using OmiconShop.Application.Repository;
using OmiconShop.Domain.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextHelper helper;

        public UserRepository(ContextHelper helper)
        {
            this.helper = helper;
        }

        public User GetUserByEmail(string email)
        {
            using (var context = helper.Create())
                return context.Users
                         .Include(x => x.UserAddress)
                         .Include(x => x.UserPersonalInformation)
                         .FirstOrDefault(x => x.Email == email);
        }

        public User GetUserById(int id)
        {
            using (var context = helper.Create())
                return context.Users
                    .Include(x => x.UserAddress)
                    .Include(x => x.UserPersonalInformation)
                    .FirstOrDefault(x => x.UserId == id);
        }

        public User ChangeUserEmail(int id, string newEmail)
        {
            var user = GetUserById(id);
            user.Email = newEmail;
            Task.Run(() => ModifyUserEmailAsync(user));

            return user;
        }

        private async Task ModifyUserEmailAsync(User user)
        {
            using (var context = helper.Create())
            {
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(string email, Action<User> modify)
        {
            using (var context = helper.Create())
            {
                var _user = GetUserByEmail(email) ?? throw new NotImplementedException();
                context.Users.Attach(_user);
                modify(_user);
                await context.SaveChangesAsync();
            }
        }
    }
}