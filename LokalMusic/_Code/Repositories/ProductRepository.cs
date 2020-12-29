﻿using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
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

                    //album.Tracks = GetTracksByAlbumId(album.AlbumId);

                    albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        //public List<Track> GetTracksByAlbumId(int albumId)
        //{
        //    List<Track> tracks = new List<Track>();

        //    string query = "SELECT * " +
        //                   "FROM Track " +
        //                   "INNER JOIN Product " +
        //                   "ON Track.TrackId = Product.ProductId " +
        //                   "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED') " +
        //                   "AND AlbumId = @AlbumId";

        //    var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
        //    bool valid = values.Rows.Count > 0;

        //    if (valid)
        //    {
        //        for (int i = 0; i < values.Rows.Count; i++)
        //        {
        //            Track track = new Track(
        //                (int)values.Rows[i]["TrackId"],
        //                (int)values.Rows[i]["AlbumId"],
        //                (int)values.Rows[i]["GenreId"],
        //                (int)values.Rows[i]["TrackFileId"],
        //                (int)values.Rows[i]["ClipFileId"],
        //                values.Rows[i]["ProductName"].ToString(),
        //                TimeSpan.Parse(values.Rows[i]["TrackDuration"].ToString()),
        //                values.Rows[i]["Description"].ToString(),
        //                TimeSpan.Parse(values.Rows[i]["ClipDuration"].ToString())
        //                );

        //            tracks.Add(track);
        //        }
        //    }

        //    return tracks.Count > 0 ? tracks : null;
        //}

        public List<AlbumProduct> GetAlbums()
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
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED')";

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

                    albums.Add(album);
                }
            }

            return albums.Count > 0 ? albums : null;
        }

        public List<Track> GetTracks()
        {
            List<Track> tracks = new List<Track>();

            string query = "SELECT * " +
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
                           "WHERE Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = 'LISTED')";

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
                        values.Rows[i]["GenreName"].ToString()
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