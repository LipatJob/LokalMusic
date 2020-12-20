using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class SessionHelper
    {
        private const string USERID_KEY = "USERID";
        public static bool IsLoggedIn()
        {
            return HttpContext.Current.Session[USERID_KEY] != null;
        }

        public static int GetUserId()
        {
            return (int) HttpContext.Current.Session[USERID_KEY];
        }

        public static void SetLoginSession(int userId)
        {
            HttpContext.Current.Session[USERID_KEY] = userId;
        }
    }
}