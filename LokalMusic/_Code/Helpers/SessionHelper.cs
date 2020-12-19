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

        public static string GetUserId()
        {
            return (string) HttpContext.Current.Session[USERID_KEY];
        }

        public static void SetLoginSession(string userId)
        {
            HttpContext.Current.Session[USERID_KEY] = userId;
        }
    }
}