using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace LokalMusic
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Off;
            routes.EnableFriendlyUrls(settings);
        }

        public static void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Collection",
                "Fan/{UserId}",
                "~/Fan/Collection.aspx"
            );
        }


    }
}
