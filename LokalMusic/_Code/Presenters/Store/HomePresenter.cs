using LokalMusic._Code.Models.Store;
using System.Collections.Generic;

namespace LokalMusic._Code.Repositories.Store
{
    public class HomePresenter
    {
        private StoreRepository repository;

        public HomePresenter(StoreRepository repo)
        {
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