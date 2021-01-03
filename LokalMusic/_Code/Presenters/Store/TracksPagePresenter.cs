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

        public List<TrackSummary> GetTracks(string sortBy = "S1", string orderBy = "ASC")
        {
            if (sortBy == "S1") sortBy = "DateAdded";
            else if (sortBy == "S2") sortBy = "TrackName";
            else if (sortBy == "S3") sortBy = "Price";
            else sortBy = "Price";

            List<TrackSummary> tracks = this.repository.GetSummarizedTracks(sortBy, orderBy);

            return tracks;
        }
    }
}