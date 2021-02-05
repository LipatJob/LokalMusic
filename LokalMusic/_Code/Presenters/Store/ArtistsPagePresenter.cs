using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic.Store;
using System;
using System.Collections.Generic;

namespace LokalMusic._Code.Presenters.Store
{
    public class ArtistsPagePresenter
    {
        private StoreRepository repository;

        public ArtistsPagePresenter( StoreRepository repo)
        {
            this.repository = repo;
        }

        public List<ArtistSummary> GetArtists(string sortBy = "s1", string orderBy = "asc")
        {
            sortBy = sortBy.ToLower();
            orderBy = orderBy.ToLower();

            if (sortBy == "s1") sortBy = "DateJoined";
            else if (sortBy == "s2") sortBy = "ArtistName";
            //else if (sortBy == "S3") sortBy = "Price"; NO PRICE FIELD IN ARTISTS
            else sortBy = "ArtistName";

            if (orderBy != "asc" && orderBy != "desc")
                orderBy = "asc";

            List<ArtistSummary> artists = this.repository.GetSummarizedArtist(sortBy, orderBy);

            foreach (var artist in artists)
            {
                if (artist == null)
                    break;

                List<TrackSummary> tracks = this.repository.GetTopTwoTracks(artist.ArtistId);

                if (tracks != null)
                {
                    if (tracks.Count >= 1)
                        artist.TrackTop1 = tracks[0];
                    if (tracks.Count >= 2)
                        artist.TrackTop2 = tracks[1];
                }

                artist.AlbumCount = this.repository.GetAlbumCountOfArtist(artist.ArtistId);
                artist.TrackTotalCount = this.repository.GetTrackCountOfArtist(artist.ArtistId);
                artist.Genre = this.repository.GetGenresOfArtist(artist.ArtistId);

            }

            return artists;
        }

    }
}