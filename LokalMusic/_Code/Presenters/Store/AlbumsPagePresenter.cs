using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public List<AlbumProduct> GetAlbums(string sortBy = "RA", string orderBy = "ASC")
        {
            if (sortBy == "RA") sortBy = "DateAdded";
            else if (sortBy == "PR") sortBy = "Price";
            else if (sortBy == "TN") sortBy = "ProductName";

            List<AlbumProduct> albums = this.repository.GetAlbums(sortBy, orderBy);

            return albums;
        }
    }
}