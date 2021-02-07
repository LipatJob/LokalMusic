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

        public static void RedirectReturnAddress(string url)
        {
            Redirect(url+ $"?ReturnAddress={HttpContext.Current.Request.Url.AbsolutePath}");
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