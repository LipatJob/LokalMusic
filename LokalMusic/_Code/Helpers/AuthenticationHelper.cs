using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class AuthenticationHelper
    {
        public const string ADMIN_USER_TYPE = "ADMIN";
        public const string ARTIST_USER_TYPE = "ARTIST";
        public const string FINANCE_USER_TYPE = "FINANCE";
        public const string FAN_USER_TYPE = "FAN";
        public const string GUEST_USER_TYPE = "GUEST";

        private const string UserIdSessionName = "USERID";
        private const string UsernameSessionName = "USERNAME";

        public static int UserId
        {
            set { HttpContext.Current.Session[UserIdSessionName] = value; }
            get { return (int)(HttpContext.Current.Session[UserIdSessionName] ?? -1); }
        }

        public static bool LoggedIn { get { return UserId != -1; } }

        public static void ClearUserSession()
        {
            HttpContext.Current.Session.Clear();
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