using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store.Details
{
    public class ArtistDetailsPresenter
    {
        private ProductDetailsRepository repository;

        public ArtistDetailsPresenter(ProductDetailsRepository repo)
        {
            this.repository = repo;
        }

    }
}