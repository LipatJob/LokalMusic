﻿using LokalMusic._Code.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class AddToCartHelper
    {

        public const int ADD_TO_CART_ERROR = 0;
        public const int ADD_TO_CART_SUCCESS = 1;
        public const int ADD_TO_CART_EXISTING = 2;
        public const int ADD_TO_CART_BOUGHT = 3;
        public const int ADD_TO_CART_LOGIN = 4;
        public const int ADD_TO_CART_ALBUMBOUGHT = 5;
        public const int ADD_TO_CART_OWNPRODUCT = 6;


        public static int AddProductToCart(int productId)
        {

            if (!AuthenticationHelper.LoggedIn)
                return ADD_TO_CART_LOGIN;

            if (AddToCartRepository.IsInCart(productId, AuthenticationHelper.UserId))
                return ADD_TO_CART_EXISTING;

            if (AddToCartRepository.IsProductBought(productId, AuthenticationHelper.UserId))
                return ADD_TO_CART_BOUGHT;

            if (AddToCartRepository.IsProductATrack(productId))
            {
                if (AddToCartRepository.IsTrackOfAlbumBought(productId, AuthenticationHelper.UserId))
                {
                    return ADD_TO_CART_ALBUMBOUGHT;
                }  
                else if (AddToCartRepository.IsUsersProductTrack(productId, AuthenticationHelper.UserId))
                {
                    return ADD_TO_CART_OWNPRODUCT;
                }                    
            }
            else
            {
                // product is an album
                if (AddToCartRepository.IsUsersProductAlbum(productId, AuthenticationHelper.UserId))
                    return ADD_TO_CART_OWNPRODUCT;
            }

            // actual adding to cart
            if (AddToCartRepository.AddToCart(productId, AuthenticationHelper.UserId) == 0)
                return ADD_TO_CART_ERROR;

            return ADD_TO_CART_SUCCESS;
        }

        public static void RemoveProductsFromCart(List<int> productIds)
        {
            if (productIds.Count > 0)
                foreach (int productId in productIds)
                    AddToCartRepository.RemoveFromCart(productId, AuthenticationHelper.UserId);
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
            else if (category == ADD_TO_CART_ALBUMBOUGHT)
                return "This track's album is already in your collection.";
            else if (category == ADD_TO_CART_OWNPRODUCT)
                return "You cannot purchase your own product.";
            else
                return "Something went wrong. Try again.";
        }


    }
}