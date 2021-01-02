using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System.Collections.Generic;

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

        public List<Track> GetTracks(string sortBy = "RA", string orderBy = "ASC")
        {
            if (sortBy == "RA") sortBy = "DateAdded";
            else if (sortBy == "PR") sortBy = "Price";
            else if (sortBy == "TN") sortBy = "ProductName";

            List<Track> tracks = this.repository.GetTracks(sortBy, orderBy);

            return tracks;
        }
    }
}