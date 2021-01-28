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

    }
}