using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish
{
    public class AlbumsRepository
    {
        public IList<AlbumsItem> GetAlbumsItems(int artistId)
        {
            string query = @"
SELECT
FileInfo.FileName AS AlbumCoverLink,
Product.ProductName AS AlbumName,
Product.DateAdded,
Album.ProducerName AS Producer,
Product.Price
FROM Product
RIGHT JOIN Album ON
Product.ProductId = Album.AlbumId
LEFT JOIN FileInfo ON
Album.AlbumCoverID = FileInfo.FileId
WHERE Album.UserId = @ArtistId
";

            var result = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));

            var Items = new List<AlbumsItem>();
            foreach (DataRow row in result.Rows)
            {
                Items.Add(new AlbumsItem() {
                    AlbumCoverLink = (string)row["AlbumCoverLink"],
                    AlbumName = (string)row["AlbumName"],
                    DateAdded = (DateTime)row["DateAdded"],
                    TrackCount = 9,
                    Producer = (string)row["Producer"],
                    SalesCount = 12,
                    Price = (decimal)row["Price"],
                    TracksURL = "~",
                    EditURL = "~"
                });
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
    }
}