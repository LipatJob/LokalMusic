using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Store
{
    public class HomePresenter
    {

        private IHomeViewModel view;
        private ProductRepository repository;

        public HomePresenter(IHomeViewModel view, ProductRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<AlbumCollection> GetBestSellingAlbums()
        {
            return this.repository.GetAlbums();
        }

        public List<Artist> GetTopArtists()
        {
            return this.repository.GetArtists();
        }

        public void Home()
        {
            //
        }

    }
}