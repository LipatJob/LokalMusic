using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class BackendAuthenticationHelper
    {
        public const string ADMIN_USER_TYPE = "ADMIN";
        public const string FINANCE_USER_TYPE = "FINANCE";
        public const string GUEST_USER_TYPE = "FINANCE";
        public const int GUEST_USER_ID = -1;

        private const string UserIdSessionName = "BACKEND_USERID";
        private const string UsernameSessionName = "BACKEND_USERNAME";

        public static int UserId
        {
            set { HttpContext.Current.Session[UserIdSessionName] = value; }
            get
            {
                if (HttpContext.Current.Session[UserIdSessionName] == null)
                {
                    return GUEST_USER_ID;
                }
                else
                {
                    return (int)HttpContext.Current.Session[UserIdSessionName];
                }
            }
        }

        public static bool LoggedIn { get { return UserId != GUEST_USER_ID; } }

        public static void ClearUserSession()
        {
            HttpContext.Current.Session[UserIdSessionName] = null;
            HttpContext.Current.Session[UsernameSessionName] = null;
        }

        public static string Username
        {
            get
            {
                if (LoggedIn == false) { return GUEST_USER_TYPE; }
                if (HttpContext.Current.Session[UsernameSessionName] != null) { return (string)HttpContext.Current.Session[UsernameSessionName]; }

                string username = GetUsernameFromDatabase();
                HttpContext.Current.Session[UsernameSessionName] = username;
                return username;
            }
        }

        private static string GetUsernameFromDatabase()
        {
            string query = "SELECT Username FROM UserInfo WHERE UserId = @UserId;";
            return (string)DbHelper.ExecuteScalar(query, ("UserId", UserId));
        }

        public static string UserType
        {
            get
            {
                if (LoggedIn == false) { return GUEST_USER_TYPE; }
                return GetUserTypeFromDatabase();
            }
        }

        private static string GetUserTypeFromDatabase()
        {
            string query = "SELECT TypeName FROM UserType WHERE UserTypeId = (SELECT UserTypeId FROM UserInfo WHERE UserId = @UserId);";
            return (string)DbHelper.ExecuteScalar(query, ("UserId", UserId));
        }
    }
}