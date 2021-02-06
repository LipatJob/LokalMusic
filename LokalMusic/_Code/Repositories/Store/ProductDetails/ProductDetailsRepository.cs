using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Store.ProductDetails
{
    public class ProductDetailsRepository
    {

        const string STATUS_PRODUCT_VISIBLE = "PUBLISHED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        // Main queries for details
        public Track GetTrackDetails(int trackId, int albumId, int artistId)
        {
            Track trackDetails = null;

            string query = "SELECT Genre.GenreName as Genre, Track.TrackId, Album.AlbumId, ArtistInfo.UserId as ArtistId, Product.ProductName as TrackName, Product.Price, Track.TrackDuration as AudioDuration, TrackAudioFile.FileName as AudioAddress, Product.DateAdded, Track.Description, AlbumProduct.ProductName as AlbumName, ArtistInfo.ArtistName, Album.DateReleased as AlbumReleaseDate, AlbumFile.FileName as AlbumCover " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON Product.ProductId = Track.TrackId " +
                           "INNER JOIN FileInfo as TrackAudioFile " +
                           "ON Track.ClipFileID = TrackAudioFile.FileId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN FileInfo as AlbumFile " +
                           "ON Album.AlbumCoverID = AlbumFile.FileId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON AlbumProduct.ProductId = Track.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "LEFT JOIN FileInfo as ArtistImageFile " +
                           "ON UserInfo.ProfileImageId = ArtistImageFile.FileId " +
                           "WHERE Track.TrackId = @TrackId AND Album.AlbumId = @AlbumId AND ArtistInfo.UserId = @ArtistId " +
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '"+ STATUS_PRODUCT_VISIBLE +"') " +
                           "AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("TrackId", trackId), ("AlbumId", albumId), ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                trackDetails = new Track(
                    (int)values.Rows[0]["TrackId"],
                    (int)values.Rows[0]["AlbumId"],
                    (int)values.Rows[0]["ArtistId"],

                    values.Rows[0]["TrackName"].ToString(),
                    Decimal.Round(Decimal.Parse(values.Rows[0]["Price"].ToString()), 2),
                    TimeSpan.Parse(values.Rows[0]["AudioDuration"].ToString()),
                    values.Rows[0]["AudioAddress"].ToString(),
                    Convert.ToDateTime(values.Rows[0]["DateAdded"].ToString()),

                    values.Rows[0]["Description"].ToString(),

                    values.Rows[0]["AlbumName"].ToString(),
                    values.Rows[0]["ArtistName"].ToString(),
                    Convert.ToDateTime(values.Rows[0]["AlbumReleaseDate"].ToString()),

                    values.Rows[0]["AlbumCover"].ToString(),

                    values.Rows[0]["Genre"].ToString().Substring(0, 1) + values.Rows[0]["Genre"].ToString().Substring(1).ToLower()
                    );
            }

            return trackDetails;
        }

        public Album GetAlbumDetails(int albumId, int artistId)
        {
            Album albumDetails = null;

            string query = "SELECT Album.AlbumId, ArtistInfo.UserId as ArtistId, Product.ProductName as AlbumName, Price, Album.Description, Album.DateReleased as ReleaseDate, FileInfo.FileName as AlbumCover, ArtistInfo.ArtistName " +
                           "FROM Album " +
                           "INNER JOIN Product " +
                           "ON Album.AlbumId = Product.ProductId " +
                           "INNER JOIN FileInfo " +
                           "ON Album.AlbumCoverID = FileInfo.FileId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "WHERE Album.AlbumId = @AlbumId AND ArtistInfo.UserId = @ArtistId " +
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId), ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                albumDetails = new Album(
                    (int)values.Rows[0]["AlbumId"],
                    (int)values.Rows[0]["ArtistId"],

                    values.Rows[0]["AlbumName"].ToString(),
                    Decimal.Round(Decimal.Parse(values.Rows[0]["Price"].ToString()), 2),
                    values.Rows[0]["Description"].ToString(),
                    Convert.ToDateTime(values.Rows[0]["ReleaseDate"].ToString()),

                    values.Rows[0]["AlbumCover"].ToString(),

                    values.Rows[0]["ArtistName"].ToString()
                    );
            }

            return albumDetails;
        }

        public Artist GetArtistDetails(int artistId)
        {
            Artist artistDetails = null;

            string query = "SELECT ArtistInfo.UserId as ArtistId, ArtistName, Bio, Location, DateRegistered as DateJoined, FileInfo.FileName as ArtistImage " +
                           "FROM ArtistInfo " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "LEFT JOIN FileInfo " +
                           "ON UserInfo.ProfileImageId = FileInfo.FileId " +
                           "WHERE UserInfo.UserId = @ArtistId " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                artistDetails = new Artist(
                    (int)values.Rows[0]["ArtistId"],

                    values.Rows[0]["ArtistName"].ToString(),
                    values.Rows[0]["Bio"].ToString(),
                    values.Rows[0]["Location"].ToString(),
                    Convert.ToDateTime(values.Rows[0]["DateJoined"].ToString()),

                    values.Rows[0]["ArtistImage"].ToString()
                    );

                if (artistDetails.ArtistImage == "")
                    artistDetails.ArtistImage = "~/Content/Images/default_artist_image.JPG";
            }

            return artistDetails;
        }

        // End Main queries for details

        // List queries
        public List<Track> GetTracksOfAlbum(int albumId, int artistId)
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT Genre.GenreName as Genre, Track.TrackId, Album.AlbumId, ArtistInfo.UserId as ArtistId, Product.ProductName as TrackName, Product.Price, Track.TrackDuration as AudioDuration, TrackAudioFile.FileName as AudioAddress, Product.DateAdded, Track.Description, AlbumProduct.ProductName as AlbumName, ArtistInfo.ArtistName, Album.DateReleased as AlbumReleaseDate, AlbumFile.FileName as AlbumCover " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON Product.ProductId = Track.TrackId " +
                           "INNER JOIN FileInfo as TrackAudioFile " +
                           "ON Track.ClipFileID = TrackAudioFile.FileId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN FileInfo as AlbumFile " +
                           "ON Album.AlbumCoverID = AlbumFile.FileId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON AlbumProduct.ProductId = Track.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "LEFT JOIN FileInfo as ArtistImageFile " +
                           "ON UserInfo.ProfileImageId = ArtistImageFile.FileId " +
                           "WHERE Album.AlbumId = @AlbumId AND ArtistInfo.UserId = @ArtistId " +
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                           "AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId), ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Track track = new Track(
                        (int)values.Rows[i]["TrackId"],
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["TrackName"].ToString(),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        TimeSpan.Parse(values.Rows[i]["AudioDuration"].ToString()),
                        values.Rows[i]["AudioAddress"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),

                        values.Rows[i]["Description"].ToString(),

                        values.Rows[i]["AlbumName"].ToString(),
                        values.Rows[i]["ArtistName"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["AlbumReleaseDate"].ToString()),

                        values.Rows[i]["AlbumCover"].ToString(),
                        values.Rows[i]["Genre"].ToString().Substring(0,1) + values.Rows[i]["Genre"].ToString().Substring(1).ToLower()
                        );

                    tracks.Add(track);
                }
            }

            return tracks;
        }

        public List<Album> GetAlbumsOfArtist(int artistId)
        {
            List<Album> albums = new List<Album>();

            string query = "SELECT Album.AlbumId, ArtistInfo.UserId as ArtistId, Product.ProductName as AlbumName, Price, Album.Description, Album.DateReleased as ReleaseDate, FileInfo.FileName as AlbumCover, ArtistInfo.ArtistName " +
                           "FROM Album " +
                           "INNER JOIN Product " +
                           "ON Album.AlbumId = Product.ProductId " +
                           "INNER JOIN FileInfo " +
                           "ON Album.AlbumCoverID = FileInfo.FileId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "WHERE ArtistInfo.UserId = @ArtistId " +
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_VISIBLE + "')  " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    Album album = new Album(
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["AlbumName"].ToString(),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["Description"].ToString(),
                        Convert.ToDateTime(values.Rows[i]["ReleaseDate"].ToString()),

                        values.Rows[i]["AlbumCover"].ToString(),

                        values.Rows[i]["ArtistName"].ToString()
                        );

                    albums.Add(album);
                }
            }

            return albums;
        }

        // End List queries

        // helper queries
        public List<string> GetAlbumGenres(int albumId)
        {
            List<string> genreList = new List<string>();

            string query = "SELECT GenreName as Genre " +
                           "FROM Product " +
                           "INNER JOIN Album " +
                           "ON Product.ProductId = Album.AlbumId " +
                           "INNER JOIN Track " +
                           "ON Album.AlbumId = Track.AlbumId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "WHERE Album.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    genreList.Add( values.Rows[i]["Genre"].ToString().Substring(0,1).ToUpper() + values.Rows[i]["Genre"].ToString().Substring(1).ToLower());
                }
            }

            return genreList;
        }

        public int GetTrackCount(int albumId)
        {
            int trackCount = 0;

            string query = "SELECT COUNT(Track.TrackId) as TrackCount " +
                           "FROM Product " +
                           "INNER JOIN Album " +
                           "ON Product.ProductId = Album.AlbumId " +
                           "INNER JOIN Track " +
                           "ON Album.AlbumId = Track.AlbumId " +
                           "WHERE Album.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                int.TryParse(values.Rows[0]["TrackCount"].ToString(), out trackCount);
            }

            return trackCount;
        }

        public string GetGenresOfAlbum(int albumId)
        {
            string query = "SELECT DISTINCT(GenreName) " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON ProductId = Track.TrackId " +
                           "INNER JOIN Genre " +
                           "ON Track.GenreId = Genre.GenreId " +
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                           "AND Track.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            List<string> genre = new List<string>();

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                    genre.Add(values.Rows[i]["GenreName"].ToString().Substring(0, 1).ToUpper() + values.Rows[i]["GenreName"].ToString().Substring(1).ToLower());

            return string.Join(", ", genre);
        }

        // End Non-core additional queries
    }
}