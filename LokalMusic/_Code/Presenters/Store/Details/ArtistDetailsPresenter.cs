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

        public (Artist, List<Album>) DetermineAlbumSummaries(Artist artist, List<Album> albums)
        {
            if (artist == null || albums.Count <= 0)
                return (artist, albums);

            // album and track count

            // append genres -- will be using the repo and sql commands
            // deteremine albums' track count using sql commands
            string genres = "";
            albums.ForEach( m => 
            {
                m.Genres = GetAlbumGenres(m.AlbumId);
                genres += m.Genres + ", "; // at this part, genres list may contain duplicated
                artist.TrackCount += GetTrackCount(m.AlbumId);
            });


            // split genres to create a list
            List<string> listGenre = genres.Split(',').Select(s => s.Trim()).ToList();
            listGenre.RemoveAt(listGenre.Count - 1); // pop last element, because there is an extra ", "
            

            artist.AlbumCount = albums.Count;
            artist.Genres = string.Join(", ", listGenre.Distinct().ToList());

            return (artist, albums);
        }

        public string GetAlbumGenres(int albumId)
        {
            return this.repository.GetAlbumGenres(albumId);
        }

        public int GetTrackCount(int albumId)
        {
            return this.repository.GetTrackCount(albumId);
        }
    }
}