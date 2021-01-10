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

        const string STATUS_PRODUCT_LISTED = "LISTED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        public Track GetTrackDetails(int trackId, int albumId, int artistId)
        {
            Track trackDetails = null;

            string query = "SELECT Track.TrackId, Album.AlbumId, ArtistInfo.UserId as ArtistId, Product.ProductName as TrackName, Product.Price, Track.TrackDuration as AudioDuration, TrackAudioFile.FileName as AudioAddress, Product.DateAdded, Track.Description, AlbumProduct.ProductName as AlbumName, ArtistInfo.ArtistName, Album.DateReleased as AlbumReleaseDate, AlbumFile.FileName as AlbumCover " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON Product.ProductId = Track.TrackId " +
                           "INNER JOIN FileInfo as TrackAudioFile " +
                           "ON Track.ClipFileID = TrackAudioFile.FileId " +
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
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '"+ STATUS_PRODUCT_LISTED +"') " +
                           "AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_LISTED + "') " +
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

                    values.Rows[0]["AlbumCover"].ToString()
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
                           "AND Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_LISTED + "') " +
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

    }
}