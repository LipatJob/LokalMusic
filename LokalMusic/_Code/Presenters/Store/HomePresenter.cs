using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Views.Store;
using System.Collections.Generic;

namespace LokalMusic._Code.Repositories.Store
{
    public class HomePresenter
    {
        private IHomeViewModel view;
        private StoreRepository repository;

        public HomePresenter(IHomeViewModel view, StoreRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<AlbumProduct> GetBestSellingAlbums()
        {
            return this.repository.GetAlbums();
        }

        public List<Artist> GetTopArtists()
        {
            return this.repository.GetArtists();
        }

        public List<Track> GetFamousTracks()
        {
            return this.repository.GetTracks();
        }

        public void Home()
        {
            //
        }
    }
}