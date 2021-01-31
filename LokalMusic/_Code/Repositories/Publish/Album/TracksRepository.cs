using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Albums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Globalization;

namespace LokalMusic._Code.Repositories.Publish.Albums
{
    public class TracksRepository
    {
        public IList<TracksItem> GetTracksItems(int albumId)
        {
            string query = @"
SELECT
    Product.ProductStatusId,
    Product.ProductId AS TrackId,
    Track.AlbumId,
    FileInfo.[FileName] AS TrackCoverLink,
    Product.ProductName AS TrackName,
    Product.DateAdded,
    Genre.GenreName AS Genre,
    Track.TrackDuration AS Duration,
    Product.Price,
    (SELECT
        COUNT(TransactionId)
    FROM TransactionProduct
    WHERE TransactionProduct.ProductId = Track.TrackId) AS SalesCount
FROM Track
    LEFT JOIN Album ON Track.AlbumId = Album.AlbumId
    LEFT JOIN Product ON Track.TrackId = Product.ProductId
    LEFT JOIN FileInfo ON Album.AlbumCoverID = FileInfo.FileId
    LEFT JOIN Genre ON Track.GenreId = Genre.GenreId
WHERE Album.AlbumId = @AlbumId
";

            var result = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));

            var Items = new List<TracksItem>();
            foreach (DataRow row in result.Rows)
            {
                if ((int)row["ProductStatusId"] == 1)
                {
                    Items.Add(new TracksItem()
                    {
                        TrackId = (int)row["TrackId"],
                        AlbumId = (int)row["AlbumId"],
                        TrackCoverLink = (string)row["TrackCoverLink"],
                        TrackName = (string)row["TrackName"],
                        DateAdded = (DateTime)row["DateAdded"],
                        Genre = new CultureInfo("en").TextInfo.ToTitleCase(row["Genre"].ToString().ToLower()),
                        Duration = (TimeSpan)row["Duration"],
                        Price = (decimal)row["Price"],
                        SalesCount = (int)row["SalesCount"]
                    });
                }
            }

            return Items;
        }

        public string GetArtistName(int artistId)
        {
            string query = "SELECT ArtistName FROM ArtistInfo WHERE UserId = @ArtistId;";
            var result = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));

            var artistName = "";
            foreach (DataRow row in result.Rows)
            {
                artistName = (string)row["ArtistName"];
            }

            return artistName;
        }

        public string GetAlbumName(int albumId)
        {
            string query = "SELECT ProductName FROM Product WHERE ProductId = @AlbumId";
            var result = DbHelper.ExecuteDataTableQuery(query, ("AlbumId", albumId));

            var albumName = "";
            foreach (DataRow row in result.Rows)
            {
                albumName = (string)row["ProductName"];
            }

            return albumName;
        }
        /**
        public int GetAlbumId(string urlAlbumName)
        {
            string query = "SELECT ProductId FROM Product WHERE REPLACE(ProductName,' ','') = @URLName";
            var result = DbHelper.ExecuteDataTableQuery(query, ("URLName", urlAlbumName));

            var albumId = 0;
            foreach (DataRow row in result.Rows)
            {
                albumId = (int)row["ProductId"];
            }

            return albumId;
        }**/
    }
}