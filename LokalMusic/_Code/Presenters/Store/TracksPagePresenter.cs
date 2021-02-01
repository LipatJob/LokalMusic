using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using System.Collections.Generic;

namespace LokalMusic._Code.Presenters.Store
{
    public class TracksPagePresenter
    {
        private StoreRepository repository;

        public TracksPagePresenter(StoreRepository repo)
        {
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