using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Cart;
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

        private CartRepository repository;

        public AddToCartPresenter(CartRepository repo)
        {
            this.repository = repo;
        }

        // Start Add to Cart static function
        // Create CartHelper
        public static int AddProductToCart(int productId)
        {
            CartRepository repo = new CartRepository();

            if (!AuthenticationHelper.LoggedIn)
                return ADD_TO_CART_LOGIN;

            if (repo.IsInCart(productId, AuthenticationHelper.UserId))
                return ADD_TO_CART_EXISTING;

            if (repo.IsProductBought(productId, AuthenticationHelper.UserId))
                return ADD_TO_CART_BOUGHT;

            if (repo.AddToCart(productId, AuthenticationHelper.UserId) == 0)
                return ADD_TO_CART_ERROR;

            return ADD_TO_CART_SUCCESS;
        }

        public static string GetAddToCartMessage(int category)
        {
            if (category == ADD_TO_CART_SUCCESS)
                return "Product added to your cart.";
            else if (category == ADD_TO_CART_BOUGHT)
                return "You have already bought this product.";
            else if (category == ADD_TO_CART_EXISTING)
                return "Product is already in your cart.";
            else if (category == ADD_TO_CART_ERROR)
                return "Unable to add to your cart. Try again later.";
            else if (category == ADD_TO_CART_LOGIN)
                return "Please login or create an account first."; //find a way to implement auto redirect
            else
                return "Something went wrong. Try again.";
        }

        // End Add to Cart static function

    }
}