using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store
{
    public class TracksPagePresenter
    {
        private ITracksPage view;
        private StoreRepository repository;
        public TracksPagePresenter(ITracksPage view, StoreRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<Track> GetTracks(string sortBy = "PR", string orderBy = "ASC")
        {
            if (sortBy == "RA") sortBy = "DateAdded";
            else if (sortBy == "PR") sortBy = "Price";
            else if (sortBy == "TL") sortBy = "ProductName";

            List<Track> tracks = this.repository.GetTracks(sortBy, orderBy);

            return tracks;
        }
    }
}