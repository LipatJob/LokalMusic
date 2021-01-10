using LokalMusic._Code.Models.Store.Details;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store.Details
{
    public class AlbumDetailsPresenter
    {
        private ProductDetailsRepository repository;

        public AlbumDetailsPresenter(ProductDetailsRepository repo)
        {
            this.repository = repo;
        }

        public Album GetAlbumDetails(int albumId, int artistId)
        {
            return this.repository.GetAlbumDetails(albumId, artistId);
        }
    }
}