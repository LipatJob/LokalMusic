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
    OrderInfo.OrderId,
    MAX(OrderInfo.OrderDate) AS Date,
    MAX(UserInfo.Username) AS Customer,
    STRING_AGG(Product.ProductName + ' (' + ProductType.TypeName + ')' , ', ') AS Products,
    SUM(ProductOrder.ProductPrice) AS AmountPaid
FROM ProductOrder
    LEFT JOIN Product ON ProductOrder.ProductId = Product.ProductId
    LEFT JOIN Track ON Track.TrackId = Product.ProductId
    LEFT JOIN Album ON Album.AlbumId = COALESCE(Track.AlbumId, Product.ProductId)
    LEFT JOIN ArtistInfo ON ArtistInfo.UserId = Album.UserId
    LEFT JOIN OrderInfo ON ProductOrder.OrderId = OrderInfo.OrderId
    LEFT JOIN UserInfo ON OrderInfo.CustomerId = UserInfo.UserId
    LEFT JOIN ProductType ON Product.ProductTypeId = ProductType.ProductTypeId
WHERE ArtistInfo.UserId = @ArtistId
GROUP BY OrderInfo.OrderId
";
            var result = DbHelper.ExecuteDataTableQuery(query, ("ArtistId", artistId));

            var items = new List<SalesItem>();
            foreach (DataRow row in result.Rows)
            {
                items.Add(new SalesItem()
                {
                    OrderID = (int)row["OrderId"],
                    Date = (DateTime)row["Date"],
                    Customer = (string)row["Customer"],
                    Products = ((string)row["Products"]).Replace("ALBUM", "Album").Replace("TRACK", "Track"),
                    AmountPaid = (decimal)row["AmountPaid"]
                });
            }

            return items;
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