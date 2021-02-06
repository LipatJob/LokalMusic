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
            // Account
            routes.MapPageRoute(
                "Collection",
                "Fan/{Username}",
                "~/Fan/Collection.aspx"
            );
            routes.MapPageRoute(
                "DefaultSettings",
                "Account/Settings",
                "~/Account/Settings/Default.aspx"
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

            // search
            routes.MapPageRoute(
                "Catalogue",
                "Store/Search/{SearchVal}",
                "~/Store/CataloguePage.aspx",
                true,
                new RouteValueDictionary { { "SearchVal", "*" } }
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


            // Publish Pages
            routes.MapPageRoute(
                "Tracks",
                "Publish/Album/{AlbumId}",
                "~/Publish/Album/Tracks.aspx");
            routes.MapPageRoute(
                "AddTrack",
                "Publish/Album/{AlbumId}/Track/Add",
                "~/Publish/Album/Track/AddTrack.aspx");
            routes.MapPageRoute(
                "EditAlbum",
                "Publish/Album/{AlbumId}/Edit",
                "~/Publish/Album/Edit.aspx");
            routes.MapPageRoute(
                "EditTrack",
                "Publish/Album/{AlbumId}/Track/{TrackId}/Edit",
                "~/Publish/Album/Track/EditTrack.aspx");

        }


    }
}
