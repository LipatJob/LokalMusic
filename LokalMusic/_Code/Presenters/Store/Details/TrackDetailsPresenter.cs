using LokalMusic._Code.Models.Store.Details;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store.Details
{
    public class TrackDetailsPresenter
    {

        private ProductDetailsRepository repository;

        public TrackDetailsPresenter(ProductDetailsRepository repo)
        {
            this.repository = repo;
        }

        public Track GetTrackDetails(int trackId, int albumId, int artistId)
        {
            return this.repository.GetTrackDetails(trackId, albumId, artistId);
        }
    }
}