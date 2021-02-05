using LokalMusic._Code.Models.Store.Details;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store.Details
{
    public class ArtistDetailsPresenter
    {
        private ProductDetailsRepository repository;

        public ArtistDetailsPresenter(ProductDetailsRepository repo)
        {
            this.repository = repo;
        }

        public Artist GetArtistDetails(int artistId)
        {
            return this.repository.GetArtistDetails(artistId);
        }

        public List<Album> GetAlbumsOfArtist(int artistId)
        {
            return this.repository.GetAlbumsOfArtist(artistId);
        }

        public (Artist, List<Album>) DetermineAristSummary(Artist artist, List<Album> albums)
        {
            // SQL Queries were used because I did not want to query the whole track and perform LINQ commands or iterations, and
            // LINQ commands were used because the List of Albums was already available.
            // Track list is not readily available, hence, I used SQL Queries

            if (artist == null || albums.Count <= 0)
                return (artist, albums);

            // Hashset automatically removes duplicates
            HashSet<string> genres = new HashSet<string>();
            albums.ForEach( m => 
            {
                genres.UnionWith(this.repository.GetAlbumGenres(m.AlbumId)); 
                artist.TrackCount += this.repository.GetTrackCount(m.AlbumId);
            });

            // set genre, join with ","
            artist.Genres = string.Join(", ", genres);

            // use the list of albums to get the count
            artist.AlbumCount = albums.Count;

            return (artist, albums);
        }

        public List<Album> DetermineAlbumsSummary(List<Album> albums)
        {

            albums.ForEach( m => m.Genres = this.repository.GetGenresOfAlbum(m.AlbumId) );
            return albums;
        }
    }
}