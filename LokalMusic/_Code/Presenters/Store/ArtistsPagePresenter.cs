using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store
{
    public class ArtistsPagePresenter
    {
        private ArtistsPage view;
        private StoreRepository repository;

        public ArtistsPagePresenter(ArtistsPage view, StoreRepository repo)
        {
            this.view = view;
            this.repository = repo;
        }

        public List<ArtistSummary> GetArtists(string sortBy = "S1", string orderBy = "ASC")
        {

            if (sortBy == "S1") sortBy = "DateJoined";
            else if (sortBy == "S2") sortBy = "ArtistName";
            //else if (sortBy == "S3") sortBy = "Price"; NO PRICE FIELD IN ARTISTS
            else sortBy = "ArtistName";

            if (orderBy != "ASC" && orderBy != "DESC")
                orderBy = "ASC";

            List<ArtistSummary> artists = this.repository.GetSummarizedArtist(sortBy, orderBy);

            foreach (var artist in artists)
            {
                List<TrackSummary> tracks = this.repository.GetTopTwoTracks(artist.ArtistId);

                if (tracks != null)
                {
                    if (tracks.Count >= 1)
                        artist.TrackTop1 = tracks[0];
                    if (tracks.Count >= 2)
                        artist.TrackTop2 = tracks[1];
                }                    
            }

            return artists;
        }
    }
}