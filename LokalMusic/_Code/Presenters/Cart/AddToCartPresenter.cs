using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Cart
{
    public class AddToCartPresenter
    {

        public const int ADD_TO_CART_ERROR = 0;
        public const int ADD_TO_CART_SUCCESS = 1;
        public const int ADD_TO_CART_EXISTING = 2;
        public const int ADD_TO_CART_BOUGHT = 3;
        public const int ADD_TO_CART_LOGIN = 4;

        public AddToCartPresenter()
        {

        }

        // Start Add to Cart static function

        public static int AddTrackToCart(int trackId, int albumId, int artistId)
        {

            //if (!AuthenticationHelper.LoggedIn)
            //    return ADD_TO_CART_LOGIN;

            return 0;
        }

        public static int AddAlbumToCart(int albumId, int artistId)
        {

            if (!AuthenticationHelper.LoggedIn)
                return ADD_TO_CART_LOGIN;

            return 0;
        }

        public static string GetAddToCartMessage(int category)
        {
            if (category == ADD_TO_CART_SUCCESS)
                return "Added to cart.";
            else if (category == ADD_TO_CART_BOUGHT)
                return "You have already bought this product.";
            else if (category == ADD_TO_CART_EXISTING)
                return "Product is already in your cart.";
            else if (category == ADD_TO_CART_ERROR)
                return "Unable to add to cart. Try again later.";
            else if (category == ADD_TO_CART_LOGIN)
                return "Please login first.";
            else
                return "Something went wrong. Try again.";
        }

        // End Add to Cart static function

    }
}