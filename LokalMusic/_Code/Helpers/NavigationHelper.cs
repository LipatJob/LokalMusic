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

        public static string CreateParameters(params (string, string)[] parameters)
        {
            string[] parameterItems = parameters.Select(parameter => $"{HttpUtility.UrlEncode(parameter.Item1)}={parameter.Item2}").ToArray();
            return string.Join("&",parameterItems);
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