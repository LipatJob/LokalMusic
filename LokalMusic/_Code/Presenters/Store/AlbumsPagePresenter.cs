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

            // foreach album get its track to get genre, track counts, track minutes

            return albums;
        }
    }
}