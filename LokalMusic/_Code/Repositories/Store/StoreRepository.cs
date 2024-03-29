﻿using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using LokalMusic._Code.Repositories.Store.ProductDetails;

// Author - Gene Garcia

namespace LokalMusic._Code.Repositories
{
    public class StoreRepository
    {

        const string STATUS_PRODUCT_VISIBLE = "PUBLISHED";
        const string STATUS_ARTIST_ACTIVE = "ACTIVE";

        private const int HOME_DISPLAY_LIMIT = 6;

        /* Summary Queries, used for products list pages */
        public List<TrackSummary> GetSummarizedTracks(string sortBy = "Price", string orderBy = "ASC")
        {
            List<TrackSummary> tracks = new List<TrackSummary>();

            string query = $@"  SELECT 
                                    TrackId, 
                                    Track.AlbumId, 
                                    Album.UserId as ArtistId, 
                                    TrackProduct.ProductName as TrackName, 
                                    TrackProduct.Price, 
                                    TrackProduct.DateAdded,
                                    AlbumProduct.ProductName as AlbumName, 
                                    ArtistInfo.ArtistName, 
                                    GenreName as Genre, 
                                    Track.TrackDuration as AudioDuration, 
                                    AlbumFile.FileName as AlbumCover
                                FROM Product as TrackProduct
                                    INNER JOIN Track ON TrackProduct.ProductId = Track.TrackId
                                    INNER JOIN Album ON Track.AlbumId = Album.AlbumId
                                    INNER JOIN Product as AlbumProduct ON Album.AlbumId = AlbumProduct.ProductId
                                    INNER JOIN Genre On Track.GenreId = Genre.GenreId
                                    INNER JOIN ArtistInfo ON Album.UserId = ArtistInfo.UserId
                                    INNER JOIN FileInfo as AlbumFile ON Album.AlbumCoverID = AlbumFile.FileId
                                    INNER JOIN FileInfo as TrackFile ON Track.ClipFileID = TrackFile.FileId
                                    INNER JOIN UserInfo ON ArtistInfo.UserId = UserInfo.UserId
                                WHERE 
                                    TrackProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY
                                    {sortBy} {orderBy}";

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
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        Convert.ToDateTime(values.Rows[i]["DateAdded"].ToString()),
                        values.Rows[i]["AlbumName"].ToString(),
                        values.Rows[i]["ArtistName"].ToString(),

                        values.Rows[i]["Genre"].ToString().Substring(0, 1) + values.Rows[i]["Genre"].ToString().Substring(1).ToLower(),

                        TimeSpan.Parse(values.Rows[i]["AudioDuration"].ToString()),

                        values.Rows[i]["AlbumCover"].ToString()
                        );

                    // check if product is in cart or bought by the user
                    if (AuthenticationHelper.LoggedIn)
                        track.AddableToCart = ProductDetailsRepository.AddableToCart(track.TrackId, AuthenticationHelper.UserId);
                    else
                        track.AddableToCart = true;

                    tracks.Add(track);
                }
            }

            return tracks;
        }
        public List<AlbumSummary> GetSummarizedAlbum(string sortBy = "Price", string orderBy = "ASC")
        {
            List<AlbumSummary> albums = new List<AlbumSummary>();

            string query = $@"  SELECT 
                                    AlbumId, 
                                    Album.UserId as ArtistId, 
                                    ProductName as AlbumName, 
                                    Price, 
                                    ProducerName, 
                                    FileInfo.FileName as AlbumCover, 
                                    ArtistName, 
                                    DateReleased
                                FROM Product
                                    INNER JOIN Album ON Product.ProductId = AlbumId
                                    INNER JOIN ArtistInfo ON Album.UserId = ArtistInfo.UserId
                                    INNER JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
                                    INNER JOIN UserInfo ON ArtistInfo.UserId = UserInfo.UserId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY 
                                    {sortBy} {orderBy}";

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
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["ProducerName"].ToString(),
                        values.Rows[i]["AlbumCover"].ToString(),

                        values.Rows[i]["ArtistName"].ToString(),

                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString())
                        );

                    // check if product is in cart or bought by the user
                    if (AuthenticationHelper.LoggedIn)
                        album.AddableToCart = ProductDetailsRepository.AddableToCart(album.AlbumId, AuthenticationHelper.UserId);
                    else
                        album.AddableToCart = true;

                    albums.Add(album);
                }
            }

            return albums;
        }
        public List<ArtistSummary> GetSummarizedArtist(string sortBy = "DateJoined", string orderBy = "ASC")
        {
            List<ArtistSummary> artists = new List<ArtistSummary>();

            string query = $@"  SELECT 
                                    ArtistInfo.UserId as ArtistId, 
                                    ArtistName, 
                                    Bio, 
                                    UserInfo.DateRegistered as DateJoined, 
                                    FileInfo.FileName as ArtistProfileImage
                                FROM ArtistInfo
                                    INNER JOIN UserInfo ON ArtistInfo.UserId = UserInfo.UserId
                                    LEFT JOIN FileInfo ON UserInfo.ProfileImageId = FileInfo.FileId
                                WHERE
                                    UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY
                                    {sortBy} {orderBy}";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    ArtistSummary artist = new ArtistSummary(
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["ArtistName"].ToString(),
                        values.Rows[i]["Bio"].ToString(),

                        Convert.ToDateTime(values.Rows[i]["DateJoined"].ToString()),

                        values.Rows[i]["ArtistProfileImage"].ToString()
                        );

                    // if there is no profile image, temporarily set the physical location to default photo
                    if (artist.ArtistProfileImage == "" || artist.ArtistProfileImage == null)
                        artist.ArtistProfileImage = "../Content/Images/default_artist_image.JPG";

                    artists.Add(artist);
                }
            }

            return artists;
        }

        /* Specialized Queries */
        public List<TrackSummary> GetHighestSoldTracks()
        {
            List<TrackSummary> tracks = new List<TrackSummary>();

            string query = $@"  SELECT TOP {HOME_DISPLAY_LIMIT} 
                                    TrackId, 
                                    Track.AlbumId, 
                                    Album.UserId as ArtistId, 
                                    Product.ProductName as TrackName, 
                                    Product.Price, 
                                    AlbumProduct.ProductName as AlbumName, 
                                    ArtistInfo.ArtistName, 
                                    FileName as AlbumCover
                                FROM Product
                                    INNER JOIN Track ON Track.TrackId = Product.ProductId
                                    INNER JOIN (
	                                    SELECT 
                                            ProductOrder.ProductId, 
                                            COUNT(ProductOrder.ProductId) as BoughtFrequency
	                                    FROM ProductOrder
	                                        INNER JOIN Track ON Track.TrackId = ProductOrder.ProductId
	                                    GROUP BY 
                                            ProductOrder.ProductId
                                    ) AS TrackBought ON Track.TrackId = TrackBought.ProductId
                                    INNER JOIN Product as AlbumProduct ON Track.AlbumId = AlbumProduct.ProductId
                                    INNER JOIN Album ON Track.AlbumId = Album.AlbumId
                                    INNER JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
                                    INNER JOIN ArtistInfo ON Album.UserId = ArtistInfo.UserId
                                    INNER JOIN UserInfo ON Album.UserId = UserInfo.UserId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND AlbumProduct.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY 
                                    BoughtFrequency DESC";

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
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["AlbumName"].ToString(),
                        values.Rows[i]["ArtistName"].ToString(),

                        values.Rows[i]["AlbumCover"].ToString()
                        );

                    tracks.Add(track);
                }
            }

            return tracks;
        }
        public List<AlbumSummary> GetHighestSoldAlbums()
        {
            List<AlbumSummary> albums = new List<AlbumSummary>();

            string query = $@"  SELECT TOP {HOME_DISPLAY_LIMIT} 
                                    AlbumId, 
                                    Album.UserId as ArtistId, 
                                    ProductName as AlbumName, 
                                    Price, ProducerName, 
                                    FileInfo.FileName as AlbumCover, 
                                    ArtistName, 
                                    DateReleased
                                FROM Product
                                    INNER JOIN Album ON Album.AlbumId = Product.ProductId
                                    INNER JOIN (
	                                    SELECT 
                                            ProductOrder.ProductId, 
                                            COUNT(ProductOrder.ProductId) as BoughtFrequency
	                                    FROM ProductOrder
	                                        INNER JOIN Album ON Album.AlbumId = ProductOrder.ProductId
	                                    GROUP BY 
                                            ProductOrder.ProductId
                                    ) AS AlbumBought ON Album.AlbumId = AlbumBought.ProductId
                                    INNER JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
                                    INNER JOIN ArtistInfo ON Album.UserId = ArtistInfo.UserId
                                    INNER JOIN UserInfo ON Album.UserId = UserInfo.UserId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatus.ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY 
                                    BoughtFrequency DESC";

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
                        Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2),
                        values.Rows[i]["ProducerName"].ToString(),
                        values.Rows[i]["AlbumCover"].ToString(),

                        values.Rows[i]["ArtistName"].ToString(),

                        Convert.ToDateTime(values.Rows[i]["DateReleased"].ToString())
                        );

                    albums.Add(album);
                }
            }

            return albums;
        }
        public List<ArtistSummary> GetMostPopularArtist()
        {
            List<ArtistSummary> artists = new List<ArtistSummary>();

            string query = $@"  SELECT TOP {HOME_DISPLAY_LIMIT} 
                                    ArtistInfo.UserId as ArtistId, 
                                    ArtistName, 
                                    Bio, 
                                    UserInfo.DateRegistered as DateJoined, 
                                    FileInfo.FileName as ArtistProfileImage
                                FROM ArtistInfo
                                    INNER JOIN (
	                                    SELECT 
                                            COALESCE(TrackAlbum.UserId, Album.UserId) as ArtistId, 
                                            COUNT(Product.ProductId) as BoughtFrequency
	                                    FROM ProductOrder
	                                        INNER JOIN Product ON ProductOrder.ProductId = Product.ProductId
	                                        LEFT JOIN Track ON Product.ProductId = Track.TrackId
	                                        LEFT JOIN Album as TrackAlbum ON TrackAlbum.AlbumId = Track.AlbumId
	                                        LEFT JOIN Album ON Product.ProductId = Album.AlbumId
	                                    GROUP BY 
                                            COALESCE(TrackAlbum.UserId, Album.UserId)
                                    ) AS ProductBought ON ArtistInfo.UserId = ProductBought.ArtistId
                                    INNER JOIN UserInfo ON ArtistInfo.UserId = UserInfo.UserId
                                    LEFT JOIN FileInfo ON UserInfo.ProfileImageId = FileInfo.FileId
                                WHERE 
                                    UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                ORDER BY 
                                    BoughtFrequency DESC";

            var values = DbHelper.ExecuteDataTableQuery(query);
            bool valid = values.Rows.Count > 0;

            if (valid)
            {
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    ArtistSummary artist = new ArtistSummary(
                        (int)values.Rows[i]["ArtistId"],

                        values.Rows[i]["ArtistName"].ToString(),
                        values.Rows[i]["Bio"].ToString(),

                        Convert.ToDateTime(values.Rows[i]["DateJoined"].ToString()),

                        values.Rows[i]["ArtistProfileImage"].ToString()
                        );

                    // if there is no profile image, temporarily set the physical location to default photo
                    if (artist.ArtistProfileImage == "" || artist.ArtistProfileImage == null)
                        artist.ArtistProfileImage = "../Content/Images/default_artist_image.JPG";

                    artists.Add(artist);
                }
            }

            return artists;
        }
        public List<TrackSummary> GetTopTwoNewTracks(int artistId)
        {
            List<TrackSummary> tracks = new List<TrackSummary>();

            string query = $@"  
                            SELECT TOP 2
                                TrackId, 
                                Track.AlbumId, 
                                Album.UserId as ArtistId, 
                                Product.ProductName as TrackName,
                                FileName as AlbumCover
                            FROM Product
                                INNER JOIN Track ON Product.ProductId = Track.TrackId
                                INNER JOIN Product AS AlbumProduct ON Track.AlbumId = AlbumProduct.ProductId
                                INNER JOIN Album ON Track.AlbumId = Album.AlbumId
                                INNER JOIN ArtistInfo ON Album.UserId = ArtistInfo.UserId
                                INNER JOIN UserInfo ON Album.UserId = UserInfo.UserId
                                INNER JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
                            WHERE
                                Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                AND AlbumProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                AND UserInfo.UserStatusId = (SELECT UserStatusId FROM UserStatus WHERE UserStatusName = '{STATUS_ARTIST_ACTIVE}')
                                AND Album.UserId = @ArtistId
                                ORDER BY Product.DateAdded DESC";

            var values = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));
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
                        values.Rows[i]["AlbumCover"].ToString()
                        );

                    tracks.Add(track);
                }
            }

            return tracks;
        }
        public List<CatalogueItem> GetSearchedProducts(string searchValue)
        {
            if (searchValue == "*") searchValue = "%%";
            else searchValue = "%" + searchValue + "%";

            List<CatalogueItem> items = new List<CatalogueItem>();

            string query = $@"
                            SELECT 
	                            COALESCE(Album.UserId, TrackAlbum.UserId) as ArtistId,
	                            COALESCE(Album.AlbumId, Track.AlbumId) as AlbumId,
	                            Track.TrackId,
	                            ProductName,
                                Price,
	                            ProductType.TypeName as ProductType,
	                            ArtistName,
	                            FileInfo.FileName as AlbumCover
                            FROM Product
	                            LEFT JOIN Album ON Product.ProductId = Album.AlbumId
	                            LEFT JOIN Track ON Product.ProductId = Track.TrackId
	                            LEFT JOIN Album AS TrackAlbum ON Track.AlbumId = TrackAlbum.AlbumId
                                INNER JOIN ProductStatus ON Product.ProductStatusId = ProductStatus.ProductStatusId
	                            INNER JOIN ProductType ON Product.ProductTypeId = ProductType.ProductTypeId
	                            INNER JOIN ArtistInfo ON ArtistInfo.UserId = COALESCE(Album.UserId, TrackAlbum.UserId)
	                            INNER JOIN UserInfo ON ArtistInfo.UserId = UserInfo.UserId
	                            INNER JOIN FileInfo ON FileInfo.FileId = COALESCE(Album.AlbumCoverID, TrackAlbum.AlbumCoverID)
                            WHERE 
	                            Product.ProductName LIKE '{searchValue}'
	                            AND ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}'
	                            AND UserInfo.UserStatusId = (SELECT UserStatus.UserStatusId FROM UserStatus WHERE UserStatus.UserStatusName = '{STATUS_ARTIST_ACTIVE}')";

            var values = DbHelper.ExecuteDataTableQuery(query, ("SearchValue", searchValue));
            bool valid = values.Rows.Count > 0;

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                {
                    CatalogueItem item = new CatalogueItem();
                    item.ArtistId = (int)values.Rows[i]["ArtistId"];
                    item.AlbumId = (int)values.Rows[i]["AlbumId"];

                    try { item.TrackId = (int)values.Rows[i]["TrackId"]; }
                    catch(Exception) { item.TrackId = 0; }

                    item.ImageCoverAddress = values.Rows[i]["AlbumCover"].ToString();
                    item.ProductName = values.Rows[i]["ProductName"].ToString();
                    item.Price = Decimal.Round(Decimal.Parse(values.Rows[i]["Price"].ToString()), 2);
                    item.ProductType = values.Rows[i]["ProductType"].ToString();
                    item.ArtistName = values.Rows[i]["ArtistName"].ToString();

                    items.Add(item);
                    }

            return items.Count > 0 ? items : null;
        }

        /* Helper Queries */
        public string GetGenreOfAlbum(int albumId)
        {
            string query = $@"  SELECT 
                                    DISTINCT(GenreName)
                                FROM Product
                                    INNER JOIN Track ON ProductId = Track.TrackId
                                    INNER JOIN Genre ON Track.GenreId = Genre.GenreId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND Track.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            List<string> genre = new List<string>();

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                    genre.Add(values.Rows[i]["GenreName"].ToString().Substring(0, 1).ToUpper() + values.Rows[i]["GenreName"].ToString().Substring(1).ToLower());

            return string.Join(", ", genre);
        }
        public (int, double) GetTrackCountAndDurationOfAlbum(int albumId)
        {
            string query = $@"  SELECT 
                                    TrackDuration
                                FROM Product
                                    INNER JOIN Track ON ProductId = Track.TrackId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND Track.AlbumId = @AlbumId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));
            bool valid = values.Rows.Count > 0;

            double totalDuration = 0;

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                    totalDuration += TimeSpan.Parse(values.Rows[i]["TrackDuration"].ToString()).TotalMinutes;

            return (values.Rows.Count, Math.Round(totalDuration, 2));
        }
        public string GetGenresOfArtist(int artistId)
        {
            string query = $@"  SELECT 
                                    DISTINCT(GenreName)
                                FROM Product
                                    INNER JOIN Album ON Product.ProductId = Album.AlbumId
                                    INNER JOIN Track ON Album.AlbumId = Track.AlbumId
                                    INNER JOIN Product as TrackProduct ON TrackProduct.ProductId = Track.TrackId
                                    INNER JOIN Genre ON Genre.GenreId = Track.GenreId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND TrackProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND Album.UserId = @ArtistId";

            var values = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));
            bool valid = values.Rows.Count > 0;

            List<string> genre = new List<string>();

            if (valid)
                for (int i = 0; i < values.Rows.Count; i++)
                    genre.Add(values.Rows[i]["GenreName"].ToString().Substring(0, 1).ToUpper() + values.Rows[i]["GenreName"].ToString().Substring(1).ToLower());

            return string.Join(", ", genre);
        }
        public int GetTrackCountOfArtist(int artistId)
        {
            string query = $@"  SELECT 
                                    COUNT(Track.TrackId) as TrackCount
                                FROM Product
                                    INNER JOIN Album ON Product.ProductId = Album.AlbumId
                                    INNER JOIN Track ON Album.AlbumId = Track.AlbumId
                                    INNER JOIN Product as TrackProduct ON TrackProduct.ProductId = Track.TrackId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND TrackProduct.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND Album.UserId = @ArtistId";

            return (int)DbHelper.ExecuteScalar(query, ("ArtistId", artistId));
        }
        public int GetAlbumCountOfArtist(int artistId)
        {
            string query = $@"  SELECT 
                                    COUNT(Album.AlbumId) as AlbumCount
                                FROM Product
                                    INNER JOIN Album ON Product.ProductId = Album.AlbumId
                                WHERE 
                                    Product.ProductStatusId = (SELECT ProductStatusId FROM ProductStatus WHERE ProductStatus.StatusName = '{STATUS_PRODUCT_VISIBLE}')
                                    AND Album.UserId = @ArtistId";

            return (int)DbHelper.ExecuteScalar(query, ("ArtistId", artistId));
        }
        public IList<FeaturedProduct> GetFeaturedProducts()
        {
            string query = @"
                            SELECT TOP 3
	                            [Album].AlbumId,
	                            [Album].UserId,
	                            [FileInfo].FileName
                            FROM [Album]
	                            INNER JOIN [Product] ON [Product].ProductId = [Album].AlbumId
	                            INNER JOIN [FileInfo] ON [FileInfo].FileId = [Album].AlbumCoverID
                            WHERE [Product].ProductStatusId = (	SELECT [ProductStatus].ProductStatusId 
									                            FROM [ProductStatus] 
									                            WHERE [ProductStatus].StatusName = 'PUBLISHED')
                            ORDER BY NEWID();";

            var result = DbHelper.ExecuteDataTableQuery(query);

            IList<FeaturedProduct> products = new List<FeaturedProduct>();
            foreach (DataRow row in result.Rows)
            {
                products.Add(new FeaturedProduct()
                {
                    ProductId = (int) row["AlbumId"],
                    ArtistId = (int) row["UserId"],
                    ProductImage = (string) row["FileName"]
                });
            }

            return products;
        }

    }
}