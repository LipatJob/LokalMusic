using LokalMusic._Code.Models.Fan;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Fan
{
    public class CollectionRepository
    {
        public ICollection<CollectionItem> GetCollection(int userId)
        {
            List<CollectionItem> items = new List<CollectionItem>();

            string query =
                "SELECT " +
                    "[FileInfo].FileName AS FileName, " +
                    "[Product].ProductName AS ProductName, " +
                    "[ArtistInfo].ArtistName AS ArtistName, " +
                    "[ProductTypes].TypeName AS ProductType, " +
                    "[ArtistInfo].UserId AS ArtistId, " +
                    "[Product].ProductId AS TrackId, " +
                    "[Album].AlbumId AS AlbumId " +
                "FROM [Transactions] " +
                    "INNER JOIN [TransactionProducts] ON " +
                        "[Transactions].TransactionId = [TransactionProducts].TransactionId " +
                    "INNER JOIN [Product] ON " +
                        "[TransactionProducts].ProductId = [Product].ProductId " +
                    "INNER JOIN [ProductTypes] ON " +
                        "[ProductTypes].ProductTypeId = [Product].ProductTypeId " +
                    "INNER JOIN [Album] ON " +
                        "[Album].AlbumId = [Product].ProductId " +
                    "INNER JOIN [ArtistInfo] ON " +
                        "[ArtistInfo].UserId = [Album].UserId " +
                    "INNER JOIN [FileInfo] ON " +
                        "[FileInfo].FileId = [Album].AlbumCoverID " +
                "WHERE " +
                    "[Transactions].UserId = @UserId";
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));
            foreach (DataRow row in result.Rows)
            {
                items.Add(new CollectionItem() {
                    CoverLink = (string)row["CoverLink"],
                    ProductName = (string)row["ProductName"],
                    ArtistName = (string)row["ArtistName"],
                    ProductType = (string)row["ProductName"],
                    ArtistId = (int)row["ArtistId"],
                    TrackId = (int)row["TrackId"],
                    AlbumId = (int)row["AlbumId"],
                }); ;
            }
            return items;
        }
    }
}