using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using System;
using System.Collections.Generic;
using System.Data;

namespace LokalMusic._Code.Repositories.Fan
{
    public class CollectionRepository
    {
        public CollectionModel SetUserInformation(string username)
        {
            string query = "SELECT UserId, FileName, Username, DateRegistered FROM [ActiveUserInfo] LEFT JOIN FileInfo ON [ActiveUserInfo].ProfileImageId = FileInfo.FileId WHERE Username = @Username";
            var result = DbHelper.ExecuteDataTableQuery(query, ("Username", username));

            if (result.Rows.Count == 0) { return null; }

            string profileImage = "~/Content/Images/Old Logo.png";
            if (result.Rows[0].IsNull("FileName") == false)
            {
                profileImage = (string)result.Rows[0]["FileName"];
            }
            var model = new CollectionModel()
            {
                UserId = (int)result.Rows[0]["UserId"],
                ProfileImage = profileImage,
                Username = (string)result.Rows[0]["Username"],
                DateRegistered = (DateTime)result.Rows[0]["DateRegistered"],
                Collection = GetCollection((int)result.Rows[0]["UserId"])
            };
            return model;
        }

        public ICollection<CollectionItem> GetCollection(int userId)
        {
            List<CollectionItem> items = new List<CollectionItem>();

            string query = @"
SELECT
	[FileInfo].FileName AS [FileName],
	[Product].ProductName AS ProductName,
	[ArtistInfo].ArtistName AS ArtistName,
	[ProductType].TypeName AS ProductType,
	[ArtistInfo].UserId AS ArtistId,
	[Product].ProductId AS TrackId,
	[Album].AlbumId AS AlbumId
FROM [OrderInfo]
	LEFT JOIN [ProductOrder] ON [ProductOrder].OrderId = [OrderInfo].OrderId
	LEFT JOIN [Product] ON [ProductOrder].ProductId = [Product].ProductId
	LEFT JOIN [ProductType] ON [ProductType].ProductTypeId = [Product].ProductTypeId
    LEFT JOIN [ProductStatus] ON [ProductStatus].ProductStatusId = [Product].ProductStatusId
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId , [Product].ProductId)
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	LEFT JOIN [FileInfo] ON [FileInfo].FileId = [Album].AlbumCoverID
WHERE
	[OrderInfo].CustomerId = @UserId AND
    [ProductStatus].ProductStatusId = (SELECT ProductStatusId FROM [ProductStatus] WHERE [ProductStatus].StatusName = 'PUBLISHED');
";
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));
            foreach (DataRow row in result.Rows)
            {
                items.Add(new CollectionItem()
                {
                    CoverLink = (string)row["FileName"],
                    ProductName = (string)row["ProductName"],
                    ArtistName = (string)row["ArtistName"],
                    ProductType = (string)row["ProductType"],
                    ArtistId = (int)row["ArtistId"],
                    TrackId = (int)row["TrackId"],
                    AlbumId = (int)row["AlbumId"],
                });
            }
            return items;
        }
    }
}