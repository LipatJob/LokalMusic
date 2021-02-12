using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Fan
{
    public class PlaylistRepository
    {

        const string STATUS_PRODUCT_VISIBLE = "PUBLISHED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        public List<PlaylistAlbum> GetPlaylistAlbum(int customerId)
        {
            List<PlaylistAlbum> albums = new List<PlaylistAlbum>();

            string query = "SELECT Album.AlbumId, ArtistInfo.ArtistName, Album.UserId as ArtistId, ProductName as AlbumName, FileName as AlbumCover " +
                            "FROM OrderInfo " +
                            "INNER JOIN ProductOrder " +
                            "ON OrderInfo.OrderId = ProductOrder.OrderId " +
                            "INNER JOIN Product " +
                            "ON ProductOrder.ProductId = Product.ProductId " +
                            "INNER JOIN Album " +
                            "ON Product.ProductId = Album.AlbumId " +
                            "LEFT JOIN FileInfo " +
                            "ON Album.AlbumCoverID = FileInfo.FileId " +
                            "INNER JOIN UserInfo " +
                            "ON Album.UserId = UserInfo.UserId " +
                            "INNER JOIN ArtistInfo " +
                            "ON ArtistInfo.UserId = UserInfo.UserId " +
                            "WHERE OrderInfo.CustomerId = @CustomerId " +
                            "AND Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '"+ STATUS_PRODUCT_VISIBLE +"') " +
                            "AND UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("CustomerId", customerId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    PlaylistAlbum album = new PlaylistAlbum();

                    album.AlbumId = (int)values.Rows[i]["AlbumId"];
                    album.ArtistId = (int)values.Rows[i]["ArtistId"];
                    album.ArtistName = values.Rows[i]["ArtistName"].ToString();
                    album.AlbumName = values.Rows[i]["AlbumName"].ToString();
                    album.AlbumCover = values.Rows[i]["AlbumCover"].ToString();
                    album.tracks = GetPlaylistTrack(album.AlbumId);

                    // only add the entry if there is/are track(s) found
                    if (album.tracks != null)
                        albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<PlaylistTrack> GetPlaylistTrack(int albumId)
        {
            List<PlaylistTrack> tracks = new List<PlaylistTrack>();

            string query = "SELECT Track.TrackId, ProductName as TrackName, FileName as AudioAddress " +
                           "FROM Product " +
                           "INNER JOIN Track " +
                           "ON Product.ProductId = Track.TrackId " +
                           "INNER JOIN FileInfo " +
                           "ON Track.TrackFileID = FileInfo.FileId " +
                           "WHERE Track.AlbumId = @AlbumId " +
                           "AND Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '" + STATUS_PRODUCT_VISIBLE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    PlaylistTrack track = new PlaylistTrack();

                    track.TrackId = (int)values.Rows[i]["TrackId"];
                    track.TrackName = values.Rows[i]["TrackName"].ToString();
                    track.TrackAudio = values.Rows[i]["AudioAddress"].ToString();

                    tracks.Add(track);
                }
            }

            return tracks.Count > 0 ? tracks : null;
        }

        public List<int> GetAlbumIdOfIndividualTracks(int userId)
        {
            List<int> albumIds = new List<int>();

            string query = "SELECT Track.AlbumId " +
                            "FROM OrderInfo " +
                            "INNER JOIN ProductOrder " +
                            "ON OrderInfo.OrderId = ProductOrder.OrderId " +
                            "INNER JOIN Product " +
                            "ON ProductOrder.ProductId = Product.ProductId " +
                            "INNER JOIN Track " +
                            "ON Product.ProductId = Track.TrackId " +
                            "WHERE OrderInfo.CustomerId = @UserId " +
                            "AND Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                            "GROUP BY Track.AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));
            bool valid = values.Rows.Count > 0;

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                    albumIds.Add( (int)values.Rows[i]["AlbumId"] );

            return albumIds;
        }

        public List<PlaylistAlbum> GetPlaylistAlbumOfIndividualTracks(int customerId, int albumId)
        {
            // the difference of this code from the above method is its less join statements in this query.
            // the parameter album id is obtained based from orderinfo and productorder

            List<PlaylistAlbum> albums = new List<PlaylistAlbum>();

            string query = "SELECT Album.AlbumId, Album.UserId as ArtistId, ArtistName, ProductName as AlbumName, FileName as AlbumCover " +
                            "FROM Product " +
                            "INNER JOIN Album " +
                            "ON Product.ProductId = Album.AlbumId " +
                            "INNER JOIN UserInfo " +
                            "ON Album.UserId = UserInfo.UserId " +
                            "INNER JOIN ArtistInfo " +
                            "ON Album.UserId = ArtistInfo.UserId " +
                            "LEFT JOIN FileInfo " +
                            "ON Album.AlbumCoverID = FileInfo.FileId " +
                            "WHERE Album.AlbumId = @AlbumId " +
                            "AND Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '" + STATUS_PRODUCT_VISIBLE + "') " +
                            "AND UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("UserId", customerId), ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    PlaylistAlbum album = new PlaylistAlbum();

                    album.AlbumId = (int)values.Rows[i]["AlbumId"];
                    album.ArtistId = (int)values.Rows[i]["ArtistId"];
                    album.ArtistName = values.Rows[i]["ArtistName"].ToString();
                    album.AlbumName = values.Rows[i]["AlbumName"].ToString();
                    album.AlbumCover = values.Rows[i]["AlbumCover"].ToString();
                    album.tracks = GetIncompleteTracks(customerId, album.AlbumId);

                    // only add the entry if there is/are track(s) found
                    if (album.tracks != null)
                        albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<PlaylistTrack> GetIncompleteTracks(int customerId, int albumId)
        {
            List<PlaylistTrack> tracks = new List<PlaylistTrack>();

            string query = "SELECT TrackId, Product.ProductName as TrackName, FileInfo.FileName as AudioAddress " +
                            "FROM OrderInfo " +
                            "INNER JOIN ProductOrder " +
                            "ON OrderInfo.OrderId = ProductOrder.OrderId " +
                            "INNER JOIN Product " +
                            "ON ProductOrder.ProductId = Product.ProductId " +
                            "INNER JOIN Track " +
                            "ON Track.TrackId = Product.ProductId " +
                            "INNER JOIN FileInfo " +
                            "ON Track.TrackFileID = FileInfo.FileId " +
                            "WHERE OrderInfo.CustomerId = @CustomerId AND Track.AlbumId = @AlbumId " +
                            "AND Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '" + STATUS_PRODUCT_VISIBLE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("CustomerId", customerId), ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for(int i = 0; i < values.Rows.Count; i++)
                {
                    PlaylistTrack track = new PlaylistTrack();

                    track.TrackId = (int)values.Rows[i]["TrackId"];
                    track.TrackName = values.Rows[i]["TrackName"].ToString();
                    track.TrackAudio = values.Rows[i]["AudioAddress"].ToString();

                    tracks.Add(track);
                }
            }

            return tracks.Count > 0 ? tracks : null;
        }
    }
}