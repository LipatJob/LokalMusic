using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class UserSeperatorHelper
    {

        /// <summary>
        /// Redirects to admin or finance landading page depending on the current user type
        /// </summary>
        public static void AllowFrontendUsers()
        {
            if (BackendAuthenticationHelper.LoggedIn)
            {
                if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.ADMIN_USER_TYPE)
                    NavigationHelper.Redirect("~/Admin/Users.aspx");
                
                else if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.FINANCE_USER_TYPE)
                    NavigationHelper.Redirect("~/Finance/Reports.aspx");
            }
                
        }

        public static void AllowBackEndUsers()
        {

        }

    }
}