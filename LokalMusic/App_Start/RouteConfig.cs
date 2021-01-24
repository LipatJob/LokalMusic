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

            // Products Page

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

            // End Products Page

            // Product Details

            routes.MapPageRoute(
                "TrackDetails",
                "Store/{ArtistId}/{AlbumId}/{TrackID}",
                "~/Store/Details/TrackDetails.aspx");

            routes.MapPageRoute(
                "AlbumDetails",
                "Store/{ArtistId}/{AlbumId}",
                "~/Store/Details/AlbumDetails.aspx");

            routes.MapPageRoute(
                "ArtistDetails",
                "Store/{ArtistId}",
                "~/Store/Details/ArtistDetails.aspx");

            // End Product Details

            // Publish Pages

            routes.MapPageRoute(
                "Tracks",
                "Publish/Album/{AlbumId}",
                "~/Publish/Album/Tracks.aspx"
                );

            // End Publish Pages
        }


    }
}
