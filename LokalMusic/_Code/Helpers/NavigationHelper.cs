using System;
using System.Web;
using System.Web.Routing;

namespace LokalMusic._Code.Helpers
{
    public class NavigationHelper
    {
        /// <summary>
        /// Redirect the request to a new URL
        /// </summary>
        /// <param name="url">The URL where the request will be redirected</param>
        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public static string GetParameterizedRoute(string routeName, object routeParameters)
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

        public static string CreateAbsoluteUrl(string relativeUrl)
        {
            return String.Format("{0}://{1}{2}",
                        HttpContext.Current.Request.Url.Scheme,
                        HttpContext.Current.Request.Url.Authority,
                        VirtualPathUtility.ToAbsolute(relativeUrl));
        }
    }
}