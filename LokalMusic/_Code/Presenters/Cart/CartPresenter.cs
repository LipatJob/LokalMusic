using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Cart;
using LokalMusic._Code.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Cart
{
    public class CartPresenter
    {

        private CartRepository repository;    
    
        public CartPresenter(CartRepository repo)
        {
            this.repository = repo;
        }

        public void PageLoad()
        {
            if (AuthenticationHelper.LoggedIn == false)
                NavigationHelper.Redirect("~/Account/Login.aspx");

        }

        public List<CartAlbum> GetCartAlbums()
        {
            return this.repository.GetAlbums(AuthenticationHelper.UserId);

        }

        public List<CartArtist> GetCartArtists()
        {
            List<CartArtist> relatedArtistInCart = this.repository.GetArtist(AuthenticationHelper.UserId);

            if (relatedArtistInCart == null)
                return null;

            List<CartArtist> artists = new List<CartArtist>();

            // not null
            foreach(CartArtist artist in relatedArtistInCart)
            {
                artist.tracks = this.repository.GetTracks(AuthenticationHelper.UserId, artist.ArtistId);

                // add this artis if it has tracks
                // in the user's cart
                if (artist.tracks != null)
                    artists.Add(artist);                    
            }

            return artists;
        }

        public bool ProcessCustomerOrder(List<CheckoutItem> checkoutItems, string paymentProvider)
        {
            bool status = false;

            if (checkoutItems != null)
                if (checkoutItems.Count > 0)
                {
                    // create order id first
                    int orderId = this.repository.CreateOrderInfo(AuthenticationHelper.UserId, checkoutItems.Sum(m => m.Price), paymentProvider);

                    if (orderId != 0)
                        // create many productorder per checkitems
                        foreach (var item in checkoutItems)
                        {
                            // insert to database
                            status = this.repository.CreateProductOrder(orderId, item.ProductId, item.Price);

                            //remove from cart
                            if (status)
                                this.repository.RemoveOrderedItemFromCart(AuthenticationHelper.UserId, item.ProductId, item.ProductType);
                        }
                }

            return status;
        }
    }
}