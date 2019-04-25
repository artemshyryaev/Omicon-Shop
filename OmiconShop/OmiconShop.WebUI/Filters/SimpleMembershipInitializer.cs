using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebMatrix.WebData;
using System.Web.Security;
using OmiconShop.Persistence;

namespace OmiconShop.WebUI.Filters
{
    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            Database.SetInitializer<ShopDBContext>(null);

            try
            {
                using (var context = new ShopDBContext())
                {
                    if (!context.Database.Exists())
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                }

                WebSecurity.InitializeDatabaseConnection("ShopDB", "Users", "Id", "Email", autoCreateTables: true);
                SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
                SimpleMembershipProvider memberships = (SimpleMembershipProvider)Membership.Provider;

                if (!roles.RoleExists("Admin"))
                {
                    roles.CreateRole("Admin");
                }

                if (memberships.GetUser("admin", false) == null)
                {
                    memberships.CreateUserAndAccount("admin", "qwerty1234");
                    roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
