using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using System.Collections.Generic;

namespace LokalMusic._Code.Presenters.Store
{
    public class AlbumsPagePresenter
    {
        private StoreRepository repository;

        public AlbumsPagePresenter(StoreRepository repo)
        {
            this.repository = repo;
        }

        public List<AlbumSummary> GetAlbums(string sortBy = "s1", string orderBy = "asc")
        {
            sortBy = sortBy.ToLower();
            orderBy = orderBy.ToLower();

            if (sortBy == "s1") sortBy = "DateReleased";
            else if (sortBy == "s2") sortBy = "AlbumName";
            else if (sortBy == "s3") sortBy = "Price";
            else sortBy = "Price";

            if (orderBy != "asc" && orderBy != "desc")
                orderBy = "asc";

            List<AlbumSummary> albums = this.repository.GetSummarizedAlbum(sortBy, orderBy);

            foreach (var album in albums)
            {
                if (album == null)
                    break;

                // SQL Queries were used because I did not want to query the whole track and perform LINQ commands or iterations
                (album.TrackCount, album.TrackMinutes) = this.repository.GetTrackCountAndDurationOfAlbum(album.AlbumId);
                album.Genre = this.repository.GetGenreOfAlbum(album.AlbumId);
            }

            return albums;
        }
    }
}