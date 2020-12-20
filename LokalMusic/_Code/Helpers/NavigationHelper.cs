using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class NavigationHelper
    {
        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public static object GetRouteValue(string key)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values[key];
        }

        public static string QueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }
    }
}