using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
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

        public List<TrackSummary> GetTracks(string sortBy = "s1", string orderBy = "asc")
        {
            sortBy = sortBy.ToLower();
            orderBy = orderBy.ToLower();

            if (sortBy == "s1") sortBy = "DateAdded";
            else if (sortBy == "s2") sortBy = "TrackName";
            else if (sortBy == "s3") sortBy = "Price";
            else sortBy = "Price";

            if (orderBy != "asc" && orderBy != "desc")
                orderBy = "asc";

            List<TrackSummary> tracks = this.repository.GetSummarizedTracks(sortBy, orderBy);

            return tracks;
        }
    }
}