using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System.Collections.Generic;

namespace LokalMusic._Code.Presenters.Store
{
    public class AlbumsPagePresenter
    {
        private IAlbumsPage view;
        private StoreRepository repository;

        public AlbumsPagePresenter(IAlbumsPage view, StoreRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<AlbumSummary> GetAlbums(string sortBy = "S1", string orderBy = "ASC")
        {
            sortBy = sortBy.ToUpper();
            orderBy = orderBy.ToUpper();

            if (sortBy == "S1") sortBy = "DateReleased";
            else if (sortBy == "S2") sortBy = "AlbumName";
            else if (sortBy == "S3") sortBy = "Price";
            else sortBy = "Price";

            if (orderBy != "ASC" && orderBy != "DESC")
                orderBy = "ASC";

            List<AlbumSummary> albums = this.repository.GetSummarizedAlbum(sortBy, orderBy);

            foreach (var album in albums)
            {
                List<TrackSummary> tracks = this.repository.GetSummarizedTracksByAlbumId(album.AlbumId);
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