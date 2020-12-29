using LokalMusic._Code.Models.Products;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author - Gene Garcia

namespace LokalMusic._Code.Repositories
{
    public class ProductRepository
    {

        const string STATUS_PRODUCT_LISTED = "LISTED";

        public List<Artist> GetCompleteProductCatalogue()
        {
            List<Artist> artists = new List<Artist>();

            string query = "SELECT * FROM ArtistInfo";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Artist artist = new Artist(
                        (int)values.Rows[i]["UserId"],
                        values.Rows[i]["ArtistName"].ToString(),
                        values.Rows[i]["Location"].ToString(),
                        values.Rows[i]["Bio"].ToString());

                    artist.Albums = GetAlbumsByUserId(artist.ArtistId);

                    artists.Add(artist);                    
                }
            }

            return artists.Count > 0 ? artists : null;
        }

        public List<Album> GetAlbumsByUserId(int userId)
        {
            List<Album> albums = new List<Album>();

            string query = "SELECT * " +
                           "FROM Album " +
                           "INNER JOIN Product " +
                           "ON Album.AlbumId = Product.ProductId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND Album.UserId = @UserId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Album album = new Album(
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["AlbumCoverId"],
                        values.Rows[i]["ProductName"].ToString(),
                        values.Rows[i]["Description"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["DateReleased"]),
                        (int)values.Rows[i]["UserId"]);

                    album.Tracks = GetTracksByAlbumId(album.AlbumId);

                    albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<Track> GetTracksByAlbumId(int albumId)
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    //TrackId = trackId;
                    //AlbumId = albumId;
                    //GenreId = genreId;
                    //TrackFileId = trackFileId;
                    //ClipFileId = clipFileId;

                    //TrackName = trackName;
                    //TrackDuration = trackDuration;
                    //Description = description;
                    //ClipDuration = clipDuration;

                    Track track = new Track(
                        (int)values.Rows[i]["TrackId"],
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["GenreId"],
                        (int)values.Rows[i]["TrackFileId"],
                        (int)values.Rows[i]["ClipFileId"],
                        values.Rows[i]["ProductName"].ToString(),
                        TimeSpan.Parse(values.Rows[i]["TrackDuration"].ToString()),
                        values.Rows[i]["Description"].ToString(),
                        TimeSpan.Parse(values.Rows[i]["ClipDuration"].ToString())
                        );

                    tracks.Add(track);
                }
            }

            return tracks.Count > 0 ? tracks : null;
        }

        public void GetProductByArtist(/*IArtistModel or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND ArtistInfo.UserId = @UserId " +
                           "AND ArtistInfo.ArtistName = @ArtistName";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count - 1; i++)
                {

                }
            }
        }

        public void GetProductByAlbum(/*IAlbum or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND Album.AlbumName = @AlbumName " +
                           "AND Album.Album.Id = @AlbumId ";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {

            }
        }

        public void GetProductByTrack(/*ITrack or Id or Name*/)
        {
            string query = "SELECT * " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + ProductRepository.STATUS_PRODUCT_LISTED + "') " +
                           "AND Track.TrackName = @TrackName " +
                           "AND Track.TrackId = @TrackId";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {

            }
        }

    }
}