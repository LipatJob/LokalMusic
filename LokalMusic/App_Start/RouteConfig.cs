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
                "~/Store/TracksPage.aspx",
                false,
                new RouteValueDictionary { { "SortBy", "S1" }, { "OrderBy", "ASC" } }
                );

            routes.MapPageRoute(
                "AlbumPage",
                "Store/Albums/{SortBy}/{OrderBy}",
                "~/Store/AlbumsPage.aspx",
                false,
                new RouteValueDictionary { { "SortBy", "S1" }, { "OrderBy", "ASC" } }
                );

            routes.MapPageRoute(
                "ArtistPage",
                "Store/Artists/{SortBy}/{OrderBy}",
                "~/Store/ArtistsPage.aspx",
                false,
                new RouteValueDictionary { { "SortBy", "S1" }, { "OrderBy", "ASC" } }
                );

            //routes.MapPageRoute(
            //    "TrackDetails",
            //    "Store/{ArtistName}/{AlbumId}/{TrackName}",
            //    "~/Store/TracksPage.aspx"
            //);

        }


    }
}
