using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Models.Account.Settings;
using LokalMusic._Code.Models.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account
{
    public class SettingsRepository
    {
        public void GetAccountDetails(int userId, IAccountSettingsModel model)
        {
            string detailsQuery = @"
SELECT
    FirstName,
    LastName,
	Email,
	Username
FROM UserInfo
WHERE [UserInfo].UserId = @UserId;
";
            var query = DbHelper.ExecuteDataTableQuery(detailsQuery, ("UserId", userId));
            model.Email = (string)query.Rows[0]["Email"];
            model.Username = (string)query.Rows[0]["Username"];
            model.FirstName = (string)query.Rows[0]["FirstName"];
            model.LastName = (string)query.Rows[0]["LastName"];

        }

        public void GetProfileDetails(int userId, IProfileSettingsModel model)
        {
            string detailsQuery = @"
SELECT
	FileName,
	COALESCE(ArtistInfo.Bio, '') AS Bio,
	COALESCE(ArtistInfo.ArtistName, '') AS ArtistName
FROM UserInfo
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [UserInfo].UserId
	LEFT JOIN [FileInfo] ON [UserInfo].ProfileImageId = [FileInfo].FileId WHERE [UserInfo].UserId = @UserId;
";

            var query = DbHelper.ExecuteDataTableQuery(detailsQuery, ("UserId", userId));
            if (query.Rows[0].IsNull("FileName"))
            {
                model.ProfileImage = "~/Content/Images/Old Logo.png";
            }
            else
            {
                model.ProfileImage = query.Rows[0]["FileName"].ToString();
            }
            model.ArtistBio = (string)query.Rows[0]["Bio"];
            model.ArtistName = (string)query.Rows[0]["ArtistName"];
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            string updatePasswordQuery = "UPDATE UserInfo SET Password = @Password WHERE UserId = @UserId";
            DbHelper.ExecuteNonQuery(updatePasswordQuery, ("Password", newPassword), ("UserId", userId));
        }

        public bool CheckPassword(int userId, string password)
        {
            string query = "SELECT UserId FROM UserInfo WHERE UserId = @UserId AND Password = @Password";
            return DbHelper.ExecuteScalar(query, ("UserId", userId), ("Password", password)) != null;
        }

        public void UpdateArtistBio(int userId, string bio)
        {
            string updateBioQuery = "UPDATE ArtistInfo SET Bio = @Bio WHERE UserId = @UserId";
            DbHelper.ExecuteNonQuery(updateBioQuery, ("Bio", bio), ("UserId", userId));

        }

        public IList<SalesListItem> GetPaymentHistory(int? userId)
        {
            string query = @"
SELECT
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].Username,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
WHERE [UserInfo].UserId = @UserId
ORDER BY [OrderInfo].OrderDate ASC;
";

            var receipts = new List<SalesListItem>();
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));

            foreach (var row in result.AsEnumerable())
            {
                receipts.Add(new SalesListItem()
                {
                    OrderId = (int)row["OrderId"],
                    AmountPaid = (decimal)row["AmountPaid"],
                    OrderDate = (DateTime)row["OrderDate"],
                    Name = (string)row["Username"]
                });
            }

            return receipts;
        }

        public void ChangeProfilePicture(int userId, HttpPostedFile file)
        {
            string fileName = userId + Path.GetExtension(file.FileName);
            if (HasProfilePicture(userId))
            {
                UpdateProfilePicture(userId, fileName, file);
            }
            else
            {
                CreateNewProfilePicture(userId, fileName, file);
            }
        }

        private void CreateNewProfilePicture(int userId, string fileName, HttpPostedFile file)
        {
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.PICTURE_CONTAINER_NAME, file, true);
            int profileImageId = (int)DbHelper.ExecuteScalar(
                "INSERT INTO FileInfo(FileTypeId, FileName) OUTPUT INSERTED.FileId VALUES((SELECT FileTypeId FROM FileType WHERE FileTypeName=@FileTypeName), @FileName)",
                ("FileTypeName", FileSystemHelper.PICTURE_CONTAINER_NAME),
                ("FileName", fileLocation));
            DbHelper.ExecuteNonQuery(
                "UPDATE UserInfo SET ProfileImageId=@ProfileImageId WHERE UserId=@UserId",
                ("ProfileImageId", profileImageId),
                ("UserId", userId));
        }

        private void UpdateProfilePicture(int userId, string fileName, HttpPostedFile file)
        {
            string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.PICTURE_CONTAINER_NAME, file, true);
            DbHelper.ExecuteNonQuery(
                "UPDATE FileInfo SET FileName = @FileName WHERE FileId = (SELECT ProfileImageId FROM UserInfo WHERE UserId=@UserId)",
                ("FileName", fileLocation),
                ("UserId", userId));
        }

        private bool HasProfilePicture(int userId)
        {
            string query = "SELECT ProfileImageId FROM UserInfo WHERE UserId = @UserId";
            return DbHelper.ExecuteScalar(query, ("UserId", userId)) != DBNull.Value;
        }

        internal IList<SalesListItem> GetReceipts(int userId)
        {

            string query = @"
SELECT
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].Username,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
WHERE [UserInfo].UserId = @UserId;
ORDER BY [OrderInfo].OrderDate DESC;
";

            var receipts = new List<SalesListItem>();
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId));

            foreach (var row in result.AsEnumerable())
            {
                receipts.Add(new SalesListItem()
                {
                    OrderId = (int)row["OrderId"],
                    AmountPaid = (decimal)row["AmountPaid"],
                    OrderDate = (DateTime)row["OrderDate"],
                    Name = (string)row["Username"]
                });
            }

            return receipts;
        }

        internal ReceiptModel GetReceiptModel(int receiptId)
        {
            string modelQuery = @"
SELECT
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].Username,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
WHERE [OrderInfo].OrderId = @OrderId;";
            var modelResult = DbHelper.ExecuteDataTableQuery(modelQuery, ("OrderId", receiptId)).Rows[0];
            var model = new ReceiptModel()
            {
                OrderId = (int)modelResult["OrderId"],
                AmountPaid = (decimal)modelResult["AmountPaid"],
                OrderDate = (DateTime)modelResult["OrderDate"],
                Name = (string)modelResult["Username"],
                Products = new List<ReceiptProductItem>()
            };

            string productsQuery = @"
SELECT
	[Product].ProductName + ' (' + [ProductType].TypeName+')' AS ProductName,
	[ProductOrder].ProductPrice
FROM [ProductOrder]
	LEFT JOIN [Product] ON [Product].ProductId = [ProductOrder].ProductId
	LEFT JOIN [ProductType] ON [Product].ProductTypeId = [ProductType].ProductTypeId
WHERE [ProductOrder].OrderId = @OrderId;";

            var productsResult = DbHelper.ExecuteDataTableQuery(productsQuery, ("OrderId", receiptId));
            foreach (var row in productsResult.AsEnumerable())
            {
                model.Products.Add(new ReceiptProductItem()
                {
                    ProductPrice = (decimal)row["ProductPrice"],
                    ProductName = (string)row["ProductName"]
                });
            }

            return model;
        }
    }
}