using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Publish
{
    public class SalesRepository
    {
        public IList<SalesItem> GetSalesItems(int artistId)
        {
            string query = @"
SELECT
TransactionProduct.TransactionId,
MAX([Transaction].TransactionDate) AS Date,
MAX(UserInfo.Username) AS Customer,
STRING_AGG(Product.ProductName + '(' + ProductType.TypeName + ')' , ', ') AS Products,
SUM(TransactionProduct.AmountPaid) AS TotalPrice
FROM Product
LEFT JOIN Track ON
Track.TrackId = Product.ProductId
LEFT JOIN Album ON
Album.AlbumId = COALESCE(Track.AlbumId, Product.ProductId)
LEFT JOIN ArtistInfo ON
ArtistInfo.UserId = Album.UserId
RIGHT JOIN TransactionProduct ON
Product.ProductId = TransactionProduct.ProductId
LEFT JOIN [Transaction] ON
TransactionProduct.TransactionId = [Transaction].TransactionId
LEFT JOIN UserInfo ON
[Transaction].UserId = UserInfo.UserId
LEFT JOIN ProductType ON
Product.ProductTypeId = ProductType.ProductTypeId
WHERE ArtistInfo.UserId = @ArtistId
GROUP BY TransactionProduct.TransactionId
";
            var result = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));

            var Items = new List<SalesItem>();
            foreach (DataRow row in result.Rows)
            {
                Items.Add(new SalesItem()
                {
                    TransactionID = (int)row["TransactionId"],
                    Date = (DateTime)row["Date"],
                    Customer = (string)row["Customer"],
                    Products = (string)row["Products"],
                    TotalPrice = (decimal)row["TotalPrice"]
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