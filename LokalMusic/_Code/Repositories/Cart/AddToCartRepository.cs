using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            string query = "SELECT * FROM OrderInfo WHERE UserId = @UserId AND ProductId = @ProductId"; // check in OrderInfo and ProducTOrder

            //return DbHelper.ExecuteScalar(query, ("UserId", userId), ("ProductId", productId)) != null ? true : false;
            return false;
        }

        public static int AddToCart(int productId, int userId)
        {
            string query = "INSERT INTO UserCart (ProductId, UserId) VALUES (@ProductId, @UserId)";
            return DbHelper.ExecuteNonQuery(query, ("ProductId", productId), ("UserId", userId));
        }

        public static int RemoveFromCart(int productId, int userId)
        {
            return 0;
        }
    }
}