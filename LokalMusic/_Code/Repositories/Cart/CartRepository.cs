using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Cart
{
    public class CartRepository
    {

        public int IsInCart(int productId, int userId)
        {
            string query = "SELECT * FROM UserCart WHERE UserId = @UserId AND ProductId = @ProductId";

            DbHelper.ExecuteScalar(query, ("UserId", userId), ("ProductId", "productId"));

            return 0;
        }

        public int AddToCart(int productId, int userId)
        {
            return 0;
        }

        public int RemoveFromCart(int productId, int userId)
        {
            return 0;
        }
    }
}