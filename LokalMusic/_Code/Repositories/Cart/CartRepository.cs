using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Cart
{
    public class CartRepository
    {
        public bool IsInCart(int productId, int userId)
        {
            return false;
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