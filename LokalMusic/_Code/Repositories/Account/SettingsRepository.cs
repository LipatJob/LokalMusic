using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
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
        public void GetUserDetails(int userId, ISettingsModel model)
        {
            string detailsQuery = "SELECT FileName, Email, Username FROM UserInfo LEFT JOIN FileInfo ON UserInfo.ProfileImageId = FileInfo.FileId WHERE UserId = @UserId;";
            var query = DbHelper.ExecuteDataTableQuery(detailsQuery, ("UserId", userId));
            if (query.Rows[0].IsNull("FileName"))
            {
                model.ProfileImage = "~/Content/Images/Logo.png";
            }
            else
            {
                model.ProfileImage = query.Rows[0]["FileName"].ToString();
            }
            model.Email = (string)query.Rows[0]["Email"];
            model.Username = (string)query.Rows[0]["Username"];
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

        public IList<PaymentHistoryItem> GetPaymentHistory(int? userId)
        {
            string productNameQuery = @"
SELECT
	[Transaction].TransactionId AS TransactionId,
	MAX(TransactionDate) AS TransactionDate,
	STRING_AGG(ProductName, ', ') AS ItemsPurchased,
	SUM([Transaction].ActualAmountPaid) AS Amount
FROM [Transaction]
	INNER JOIN TransactionProduct ON
		[Transaction].TransactionId = [TransactionProduct].TransactionId
	INNER JOIN Product ON
		[Product].ProductId = [TransactionProduct].ProductId
WHERE [Transaction].UserId = @UserId
GROUP BY [Transaction].TransactionId
ORDER BY TransactionDate DESC;
";
            var result = DbHelper.ExecuteDataTableQuery(productNameQuery, ("UserId", userId));

            return result.AsEnumerable().Select((row) =>
            {
                return new PaymentHistoryItem()
                {
                    TransactionId = (int)row["TransactionId"],
                    TransactionDate = (DateTime)row["TransactionDate"],
                    ItemsPurchased = (string)row["ItemsPurchased"],
                    Amount = (decimal)row["Amount"]
                };
            }).ToList();
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
                "INSERT INTO FileInfo(FileTypeId, FileName) VALUES((SELECT FileTypeId FROM FileType WHERE FileTypeName=@FileTypeName), @FileName) SELECT SCOPE_IDENTITY()",
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
            return DbHelper.ExecuteScalar(query, ("UserId", userId)) != null;
        }
    }
}