using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class ProductHelper
    {
        public static int GetProductOwnerId(int productId)
        {
            string query = @"
SELECT
	Album.UserId AS ArtistId
FROM Product
	LEFT JOIN Track ON Track.TrackId = Product.ProductId
	LEFT JOIN Album ON Album.AlbumId = COALESCE(Track.AlbumId, Product.ProductId)
WHERE Product.ProductId = @ProductId";

            return (int) DbHelper.ExecuteScalar(query, ("ProductId", productId));
        }

        public static bool IsValidProductId(int productId)
        {
            string query = "SELECT ProductId FROM Product WHERE Product.ProductId = @ProductId";
            return DbHelper.ExecuteDataTableQuery(query, ("ProductId", productId)).Rows.Count > 0;
        }

        public static bool IsValidTrackId(int trackId)
        {
            string query = "SELECT TrackId FROM Track WHERE Track.TrackId = @TrackId";
            return DbHelper.ExecuteDataTableQuery(query, ("TrackId", trackId)).Rows.Count > 0;
        }

        public static bool IsValidAlbumId(int albumId)
        {
            string query = "SELECT AlbumId FROM Album WHERE Album.AlbumId = @AlbumId";
            return DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId)).Rows.Count > 0;
        }

        public static void CheckAlbumOwnership()
        {
            object albumRouteValue = NavigationHelper.GetRouteValue("AlbumId");
            if (
                albumRouteValue == null || !int.TryParse((string)albumRouteValue, out int albumId) ||
                !IsValidAlbumId(albumId) || GetProductOwnerId(albumId) != AuthenticationHelper.UserId
                )
            {
                NavigationHelper.Redirect("~/Publish/Albums");
            }

        }

        public static void CheckTrackOwnership()
        {
            object trackRouteValue = NavigationHelper.GetRouteValue("TrackId");
            object albumRouteValue = NavigationHelper.GetRouteValue("AlbumId");

            int albumId = -1;
            int trackId = -1;
            if (
                albumRouteValue == null || !int.TryParse((string)albumRouteValue, out albumId) ||
                !IsValidAlbumId(albumId) || GetProductOwnerId(albumId) != AuthenticationHelper.UserId
                )
            {
                NavigationHelper.Redirect("~/Publish/Albums");
            }

            if (trackRouteValue == null || !int.TryParse((string)trackRouteValue, out trackId))
            {
                NavigationHelper.Redirect("~/Publish/Albums");
            }
            else if (!IsValidTrackId(trackId) || GetProductOwnerId(trackId) != AuthenticationHelper.UserId)
            {
                NavigationHelper.Redirect($"~/Publish/Album/{albumId}");
            }
        }

    }
}