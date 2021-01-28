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



    }
}