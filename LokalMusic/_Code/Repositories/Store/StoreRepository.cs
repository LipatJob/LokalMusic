using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Author - Gene Garcia

namespace LokalMusic._Code.Repositories
{
    public class StoreRepository
    {

        const string STATUS_PRODUCT_LISTED = "LISTED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        /* Summary Queries */

        public List<TrackSummary> GetSummarizedTracks(string sortBy = "Price", string orderBy = "ASC")
        {
            List<TrackSummary> tracks = new List<TrackSummary>();

            string query = "SELECT TrackId, Track.AlbumId, Album.UserId as ArtistId, TrackProduct.ProductName as TrackName, TrackProduct.Price, TrackProduct.DateAdded, AlbumProduct.ProductName as AlbumName, ArtistInfo.ArtistName, GenreName as Genre, TrackFile.FileName as AudioClip, Track.ClipDuration as AudioClipDuration, Track.TrackDuration as AudioDuration, AlbumFile.FileName as AlbumCover " +
                           "FROM Product as TrackProduct " +
                           "INNER JOIN Track " +
                           "ON TrackProduct.ProductId = Track.TrackId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON Album.AlbumId = AlbumProduct.ProductId " +
                           "INNER JOIN Genre " +
                           "On Track.GenreId = Genre.GenreId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN FileInfo as AlbumFile " +
                           "ON Album.AlbumCoverID = AlbumFile.FileId " +
                           "INNER JOIN FileInfo as TrackFile " +
                           "ON Track.ClipFileID = TrackFile.FileId " +
                           "WHERE TrackProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '"+ STATUS_PRODUCT_LISTED + "')" +
                           "ORDER BY " + sortBy + " " + orderBy;

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    TrackSummary track = new TrackSummary(
                        (int)values.Rows[i]["TrackId"],
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["TrackName"].ToString(),
                        Decimal.Parse(values.Rows[i]["Price"].ToString()),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),
                        values.Rows[i]["AlbumName"].ToString(),
                        values.Rows[i]["ArtistName"].ToString(),

                        values.Rows[i]["Genre"].ToString(),

                        values.Rows[i]["AudioClip"].ToString(),
                        TimeSpan.Parse(values.Rows[i]["AudioClipDuration"].ToString()),
                        TimeSpan.Parse(values.Rows[i]["AudioDuration"].ToString()),

                        values.Rows[i]["AlbumCover"].ToString()
                        );
                }
            }

            return tracks.Count() > 0 ? tracks : null;
        }

        public List<AlbumSummary> GetSummarizedAlbum(string sortBy = "Price", string orderBy = "ASC")
        {
            List<AlbumSummary> decimals = new List<AlbumSummary>();

            string query = "SELECT AlbumId, UserId as ArtistId, ProductName as AlbumName, Price, ProducerName, FileInfo.FileName as AlbumCover, DateReleased " +
                           "FROM Product " +
                           "INNER JOIN Album " +
                           "ON Product.ProductId = AlbumId " +
                           "INNER JOIN FileInfo " +
                           "On Album.AlbumCoverID = FileInfo.FileId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED')" +
                           "ORDER BY " + sortBy + " " + orderBy;

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    AlbumSummary album = new AlbumSummary(
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["AlbumName"].ToString(),
                        Decimal.Parse(values.Rows[i]["Price"].ToString()),
                        values.Rows[i]["ProducerName"].ToString(),
                        values.Rows[i]["AlbumCover"].ToString(),

                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString())
                        );
                }
            }

            return decimals.Count() > 0 ? decimals : null;
        }

        public List<ArtistSummary> GetSummarizedArtist(string sortBy = "Price", string orderBy = "ASC")
        {
            List<ArtistSummary> artist = new List<ArtistSummary>();

            string query = "SELECT ArtistInfo.UserId as ArtistId, ArtistName, Bio, UserInfo.DateRegistered as DateJoined, FileInfo.FileName as ArtistProfileImage " +
                           "FROM ArtistInfo " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "LEFT JOIN FileInfo " +
                           "ON UserInfo.ProfileImageId = FileInfo.FileId " +
                           "WHERE UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '"+ STATUS_ARTIST_ACTIVE +"')" +
                           "ORDER BY " + sortBy + " " + orderBy;

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {

                }
            }

            return artist.Count() > 0 ? artist : null;
        }

        /* Old */

        public List<Artist> GetArtists(bool artistInfoOnly = true)
        {
            List<Artist> artists = new List<Artist>();

            string query = "SELECT * " +
                           "FROM ArtistInfo " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "LEFT JOIN FileInfo " +
                           "ON UserInfo.ProfileImageId = FileInfo.FileId " +
                           "WHERE UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = 'ACTIVE')";

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
                        values.Rows[i]["Bio"].ToString(),
                        values.Rows[i]["Email"].ToString(),
                        values.Rows[i]["Username"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["DateRegistered"].ToString()),
                        values.Rows[i]["FileName"].ToString()
                        );

                    if (!artistInfoOnly)
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
                        (int)values.Rows[i]["UserId"],
                        (double)values.Rows[i]["Price"]);

                    album.Tracks = GetTracksByAlbumId(album.AlbumId);

                    albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<Track> GetTracksByAlbumId(int albumId)
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT Track.TrackId, Product.ProductName, Track.Description, Track.TrackDuration, Track.ClipDuration, Product.DateAdded, Album.DateReleased, Product.Price, Album.ProducerName, FileInfo.FileName, ArtistInfo.UserId, ArtistInfo.ArtistName, Track.AlbumId, Genre.GenreName, AlbumProduct.ProductName as AlbumName " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "INNER JOIN FileInfo " +
                           "ON Track.ClipFileID = FileInfo.FileId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON Track.AlbumId = AlbumProduct.ProductId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "AND Track.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Track track = new Track(
                        (int)values.Rows[i]["TrackId"],
                        values.Rows[i]["ProductName"].ToString(),
                        values.Rows[i]["Description"].ToString(),
                        TimeSpan.Parse(values.Rows[i]["TrackDuration"].ToString()),
                        TimeSpan.Parse(values.Rows[i]["ClipDuration"].ToString()),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),
                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString()),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["ProducerName"].ToString(),
                        values.Rows[i]["FileName"].ToString(),
                        (int)values.Rows[i]["UserId"],
                        values.Rows[i]["ArtistName"].ToString(),
                        (int)values.Rows[i]["AlbumId"],
                        values.Rows[i]["GenreName"].ToString(),
                        values.Rows[i]["AlbumName"].ToString());

                    tracks.Add(track);
                }
            }

            return tracks.Count > 0 ? tracks : null;
        }

        public List<AlbumProduct> GetAlbums(string sortBy = "DateAdded", string orderBy = "ASC", bool withTracks = false)
        {
            List<AlbumProduct> albums = new List<AlbumProduct>();

            string query = "SELECT * " +
                           "FROM Product " +
                           "INNER JOIN Album " +
                           "ON Product.ProductId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN FileInfo " +
                           "ON FileInfo.FileId = Album.AlbumCoverId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED')" +
                           "ORDER BY " + sortBy + " " + orderBy;

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    AlbumProduct album = new AlbumProduct(
                        (int)values.Rows[i]["AlbumId"],
                        values.Rows[i]["ProductName"].ToString(),
                        values.Rows[i]["Description"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString()),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["ProducerName"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),
                        (int)values.Rows[i]["UserId"],
                        values.Rows[i]["ArtistName"].ToString(),
                        values.Rows[i]["Location"].ToString(),
                        values.Rows[i]["Bio"].ToString(),
                        values.Rows[i]["FileName"].ToString());

                    if (withTracks)
                        album.Tracks = this.GetTracksByAlbumId(album.AlbumId);

                    albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<Track> GetTracks(string sortBy = "DateAdded", string orderBy = "ASC")
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT Track.TrackId, Product.ProductName, Track.Description, Track.TrackDuration, Track.ClipDuration, Product.DateAdded, Album.DateReleased, Product.Price, Album.ProducerName, FileInfo.FileName, ArtistInfo.UserId, ArtistInfo.ArtistName, Track.AlbumId, Genre.GenreName, AlbumProduct.ProductName as AlbumName " +
                           "FROM Track " +
                           "INNER JOIN Product " +
                           "ON Track.TrackId = Product.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "INNER JOIN FileInfo " +
                           "ON Track.ClipFileID = FileInfo.FileId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON Track.AlbumId = AlbumProduct.ProductId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
                           "ORDER BY " + sortBy + " " + orderBy;

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Track track = new Track(
                        (int)values.Rows[i]["TrackId"],
                        values.Rows[i]["ProductName"].ToString(),
                        values.Rows[i]["Description"].ToString(),
                        TimeSpan.Parse(values.Rows[i]["TrackDuration"].ToString()),
                        TimeSpan.Parse(values.Rows[i]["ClipDuration"].ToString()),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),
                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString()),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["ProducerName"].ToString(),
                        values.Rows[i]["FileName"].ToString(),
                        (int)values.Rows[i]["UserId"],
                        values.Rows[i]["ArtistName"].ToString(),
                        (int)values.Rows[i]["AlbumId"],
                        values.Rows[i]["GenreName"].ToString(),
                        values.Rows[i]["AlbumName"].ToString()
                        );

                    tracks.Add(track);
                }
            }

                return tracks.Count > 0 ? tracks : null;
        }

    }
}