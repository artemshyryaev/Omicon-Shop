using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Startersite.Managers
{
    public class IdentityExtensions
    {
        MembershipUserCollection users;

        public void Page_Load()
        {
            users = Membership.GetAllUsers();
            MembershipUser u = users.c;

            var user = User.

            EmailLabel.Text = u.Email;
        }
    }