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
                "Fan/{Username}",
                "~/Fan/Collection.aspx"
            );

            routes.MapPageRoute(
                "TrackPage",
                "Store/Tracks/{SortBy}/{OrderBy}",
                "~/Store/TracksPage.aspx"
                );

            routes.MapPageRoute(
                "TrackDetails",
                "Store/{ArtistName}/{AlbumId}/{TrackName}",
                "~/Store/TracksPage.aspx"
            );

        }


    }
}
