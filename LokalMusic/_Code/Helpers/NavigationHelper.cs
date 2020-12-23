using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace LokalMusic._Code.Helpers
{
    public class NavigationHelper
    {
        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public static string GetRouteUrl(string routeName, object routeParameters)
        {
            var dict = new RouteValueDictionary(routeParameters);
            var data = RouteTable.Routes.GetVirtualPath(HttpContext.Current.Request.RequestContext, routeName, dict);
            if (data != null)
            {
                return data.VirtualPath;
            }
            return null;
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