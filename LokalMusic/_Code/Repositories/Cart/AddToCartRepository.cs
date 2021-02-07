using LokalMusic._Code.Helpers;

namespace LokalMusic._Code.Repositories.Cart
{
    public class AddToCartRepository
    {

        public static bool IsInCart(int productId, int userId)
        {
            string query = "SELECT * FROM UserCart WHERE UserId = @UserId AND ProductId = @ProductId"; // listed artist album or track

            return DbHelper.ExecuteScalar(query, ("UserId", userId), ("ProductId", productId)) != null ? true : false;
        }

        public static bool IsProductBought(int productId, int userId)
        {
            string query = "SELECT ProductOrderId " +
                           "FROM ProductOrder " +
                           "INNER JOIN OrderInfo  " +
                           "ON ProductOrder.OrderId = OrderInfo.OrderId  " +
                           "WHERE ProductId = @ProductId AND CustomerId = @CustomerId";

            return DbHelper.ExecuteScalar(query, ("CustomerId", userId), ("ProductId", productId)) != null ? true : false;
        }

        public static bool IsUsersProductAlbum(int productId, int userId)
        {
            string query = "SELECT Product.ProductId " +
                           "FROM Product " +
                           "INNER JOIN Album " +
                           "ON Product.ProductId = Album.AlbumId " +
                           "WHERE Album.UserId = @UserArtistId AND Product.ProductId = @ProductId";

            return DbHelper.ExecuteScalar(query, ("UserArtistId", userId), ("ProductId", productId)) != null ? true : false;
        }

        public static bool IsUsersProductTrack(int productId, int userId)
        {
            string query = "SELECT Product.ProductId " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON Product.ProductId = Track.TrackId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "WHERE Album.UserId = @UserArtistId AND Product.ProductId = @ProductId";

            return DbHelper.ExecuteScalar(query, ("UserArtistId", userId), ("ProductId", productId)) != null ? true : false;
        }

        public static bool IsProductATrack(int productId)
        {
            string query = "SELECT ProductId " +
                           "FROM Product " +
                           "WHERE ProductId = @ProductId " +
                           "AND ProductTypeId = (SELECT ProductType.ProductTypeId FROM ProductType WHERE ProductType.TypeName = 'TRACK')";

            return DbHelper.ExecuteScalar(query, ("ProductId", productId)) != null ? true : false;
        }

        public static int GetAlbumIdOfTrack(int trackId)
        {
            string query = "SELECT AlbumId " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON ProductId = TrackId " +
                           "WHERE ProductId = @TrackId";

            return (int)DbHelper.ExecuteScalar(query, ("TrackId", trackId));
        }

        public static bool IsTrackOfAlbumBought(int trackId, int userId)
        {
            int albumId = GetAlbumIdOfTrack(trackId);

            if (albumId <= 0) return false;

            string query = "SELECT OrderInfo.OrderId " +
                           "FROM OrderInfo " +
                           "INNER JOIN ProductOrder " +
                           "ON OrderInfo.OrderId = ProductOrder.OrderId " +
                           "WHERE CustomerId = @CustomerId " +
                           "AND ProductOrder.ProductId = @AlbumId";

            return DbHelper.ExecuteScalar(query, ("CustomerId", userId), ("AlbumId", albumId)) != null ? true : false;
        }

        public static int AddToCart(int productId, int userId)
        {
            string query = "INSERT INTO UserCart (ProductId, UserId) VALUES (@ProductId, @UserId)";
            return DbHelper.ExecuteNonQuery(query, ("ProductId", productId), ("UserId", userId));
        }

    }
}