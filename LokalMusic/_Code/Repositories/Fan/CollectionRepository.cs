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
            string profileImage = "~/Content/Images/Logo.png";
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
FROM [Transaction]
	INNER JOIN [TransactionProduct] ON [Transaction].TransactionId = [TransactionProduct].TransactionId
	INNER JOIN [Product] ON [TransactionProduct].ProductId = [Product].ProductId
	INNER JOIN [ProductType] ON [ProductType].ProductTypeId = [Product].ProductTypeId
	INNER JOIN [Album] ON [Album].AlbumId = [Product].ProductId
	INNER JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	INNER JOIN [FileInfo] ON [FileInfo].FileId = [Album].AlbumCoverID
WHERE
	[Transaction].UserId = @UserId
";
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));
            foreach (DataRow row in result.Rows)
            {
                items.Add(new CollectionItem()
                {
                    CoverLink = (string)row["FileName"],
                    ProductName = (string)row["ProductName"],
                    ArtistName = (string)row["ArtistName"],
                    ProductType = (string)row["ProductName"],
                    ArtistId = (int)row["ArtistId"],
                    TrackId = (int)row["TrackId"],
                    AlbumId = (int)row["AlbumId"],
                });
            }
            return items;
        }
    }
}