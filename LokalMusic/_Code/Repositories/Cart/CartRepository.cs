﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Cart
{
    public class CartRepository
    {
        const string STATUS_PRODUCT_LISTED = "LISTED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        public List<CartAlbum> GetAlbums(int customerId)
        {
            List<CartAlbum> albums = new List<CartAlbum>();

            string query = "SELECT Album.AlbumId, ArtistInfo.UserId as ArtistId, AlbumProduct.ProductName as AlbumName, ArtistName, AlbumProduct.Price, FileName as AlbumCoverAddress " +
                           "FROM UserCart " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON UserCart.ProductId = AlbumProduct.ProductId " +
                           "INNER JOIN Album " +
                           "ON AlbumProduct.ProductId = Album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON Album.UserId = UserInfo.UserId " +
                           "INNER JOIN FileInfo " +
                           "ON Album.AlbumCoverID = FileInfo.FileId " +
                           "WHERE UserCart.UserId = @CustomerId " +
                           "AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_LISTED + "') " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("CustomerId", customerId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    CartAlbum album = new CartAlbum(
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["AlbumName"].ToString(),
                        values.Rows[i]["ArtistName"].ToString(),
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),

                        values.Rows[i]["AlbumCoverAddress"].ToString()
                        );

                    albums.Add(album);
                }
            }


            return albums.Count > 0 ? albums : null;
        }

        public List<CartArtist> GetArtist(int customerId)
        {
            List<CartArtist> artists = new List<CartArtist>();

            string query = "SELECT DISTINCT(Album.UserId) as ArtistId, ArtistName " +
                           "FROM UserCart " +
                           "INNER JOIN Product AS TrackProduct " +
                           "ON UserCart.ProductId = TrackProduct.ProductId " +
                           "INNER JOIN Track " +
                           "ON TrackProduct.ProductId = Track.TrackId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = album.AlbumId " +
                           "INNER JOIN ArtistInfo " +
                           "ON Album.UserId = ArtistInfo.UserId " +
                           "INNER JOIN UserInfo " +
                           "ON ArtistInfo.UserId = UserInfo.UserId " +
                           "WHERE UserCart.UserId = @CustomerId " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("CustomerId", customerId));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    CartArtist artist = new CartArtist(
                        (int)values.Rows[i]["ArtistId"],
                        values.Rows[i]["ArtistName"].ToString()
                        );

                    artists.Add(artist);
                }
            }

            return artists.Count > 0 ? artists : null;
        }

        public List<CartTrack> GetTracks(int customerId, string albumIds)
        {
            List<CartTrack> tracks = new List<CartTrack>();

            string query = "SELECT TrackId, AlbumProduct.ProductId as AlbumId, Album.UserId as ArtistId, " +
                           "TrackProduct.ProductName as TrackName, AlbumProduct.ProductName as AlbumName,  " +
                           "TrackProduct.Price, Track.TrackDuration as AudioLength, FileInfo.FileName as AlbumCover " +
                           "FROM UserCart " +
                           "INNER JOIN Product AS TrackProduct " +
                           "ON UserCart.ProductId = TrackProduct.ProductId " +
                           "INNER JOIN Track " +
                           "ON TrackProduct.ProductId = Track.TrackId " +
                           "INNER JOIN Product as AlbumProduct " +
                           "ON Track.AlbumId = AlbumProduct.ProductId " +
                           "INNER JOIN Album " +
                           "ON Track.AlbumId = Album.AlbumId " +
                           "INNER JOIN FileInfo " +
                           "ON Album.AlbumCoverID = FileInfo.FileId " +
                           "INNER JOIN UserInfo " +
                           "ON Album.UserId = UserInfo.UserId " +
                           "WHERE UserCart.UserId = @CustomerId " +
                           "AND Album.AlbumId NOT IN(@AlbumIds)  " +
                           "AND TrackProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_LISTED + "') " +
                           "AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '" + STATUS_PRODUCT_LISTED + "') " +
                           "AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '" + STATUS_ARTIST_ACTIVE + "')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("CustomerId", customerId), ("AlbumIds", albumIds));
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    CartTrack track = new CartTrack(
                        (int)values.Rows[i]["TrackId"],
                        (int)values.Rows[i]["AlbumId"],
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["TrackName"].ToString(),
                        values.Rows[i]["AlbumName"].ToString(),

                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),

                        TimeSpan.Parse(values.Rows[i]["AudioLength"].ToString()).TotalMinutes,
                        values.Rows[i]["AlbumCover"].ToString()
                        );

                    tracks.Add(track);
                }
            }

            return tracks.Count > 0 ? tracks : null;
        }

    }
}