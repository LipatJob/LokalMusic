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

                List<TrackSummary> tracks = this.repository.GetSummarizedTracksByAlbumId(album.AlbumId);

                if (tracks == null)
                    break;

                album.TrackCount = tracks.Count;

                double totalMinutes = 0;
                tracks.ForEach(m =>{ totalMinutes += m.AudioDuration.TotalMinutes; });
                album.TrackMinutes = System.Math.Round(totalMinutes, 2);

                List<string> genres = new List<string>();
                tracks.ForEach(m => genres.Add( m.Genre.Substring(0,1).ToUpper() + m.Genre.Substring(1).ToLower() ));

                album.Genre = string.Join(", ", genres);
            }

            return albums;
        }
    }
}