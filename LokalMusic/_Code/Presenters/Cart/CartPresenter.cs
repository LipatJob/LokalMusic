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

        public void ProcessCustomerOrder(List<CheckoutItem> checkoutItems)
        {



        }
    }
}