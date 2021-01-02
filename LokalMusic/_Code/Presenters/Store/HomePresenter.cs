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
        private StoreRepository repository;

        public HomePresenter(IHomeViewModel view, StoreRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<AlbumSummary> GetBestSellingAlbums()
        {
            return this.repository.GetHighestSoldAlbums();
        }

        public List<ArtistSummary> GetTopArtists()
        {
            return this.repository.GetMostPopularArtist();
        }

        public List<TrackSummary> GetFamousTracks()
        {
            return this.repository.GetHighestSoldTracks();
        }

        public void Home()
        {
            //
        }

    }
}