using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;

namespace Startersite.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class InitializeSimpleMembershopAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }
    }

    class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {
            try
            {
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