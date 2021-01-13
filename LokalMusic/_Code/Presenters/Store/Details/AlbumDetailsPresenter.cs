using LokalMusic._Code.Models.Store.Details;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store.Details
{
    public class AlbumDetailsPresenter
    {
        private ProductDetailsRepository repository;

        public AlbumDetailsPresenter(ProductDetailsRepository repo)
        {
            this.repository = repo;
        }

        public Album GetAlbumDetails(int albumId, int artistId)
        {
            return this.repository.GetAlbumDetails(albumId, artistId);
        }

        public List<Track> GetTracksOfAlbum(int albumId, int artistId)
        {
            return this.repository.GetTracksOfAlbum( albumId, artistId);
        }

        public Album DetermineTrackSummaries(Album album, List<Track> tracks)
        {
            // concat genres
            // determine track count
            // determine total track length

            if (tracks.Count <= 0 || album == null)
                return album;

            List<string> genres = new List<string>();
            tracks.ForEach(m => {
                genres.Add(m.Genre.Substring(0, 1).ToUpper() + m.Genre.Substring(1).ToLower());
                album.MinuteCount += m.AudioDuration.TotalMinutes;
            } );

            album.Genres = string.Join(", ", genres.Distinct().ToList());
            album.TrackCount = tracks.Count;

            return album;
        }

    }
}