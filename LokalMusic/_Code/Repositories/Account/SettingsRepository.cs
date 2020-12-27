using LokalMusic._Code.Models.Account;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account
{
    public class SettingsRepository
    {
        public void GetUserDetails(int userId, ISettingsModel model)
        {
            string detailsQuery = "SELECT Email, Username FROM UserInfo WHERE UserId = @UserId;";
            var query = DbHelper.ExecuteDataTableQuery(detailsQuery, ("UserId", userId));
            model.Email = (string)query.Rows[0]["Email"];
            model.Username = (string)query.Rows[0]["Username"];
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            string updatePasswordQuery = "UPDATE UserInfo SET Password = @Password WHERE UserId = @UserId";
            DbHelper.ExecuteCommand(updatePasswordQuery, ("Password", newPassword), ("UserId", userId));
            return true;
        }

        public bool CheckPassword(int userId, string password)
        {
            string query = "SELECT UserId FROM UserInfo WHERE UserId = @UserId AND Password = @Password";
            var result = DbHelper.ExecuteDataTableQuery(query, ("UserId", userId), ("Password", password));
            return result.Rows.Count == 1;
        }

        public IList<PaymentHistoryItem> GetPaymentHistory(int? userId)
        {
            var paymentHistory = new List<PaymentHistoryItem>();

            
            string transactionQuery = "SELECT  FROM TransactionInfo WHERE UserId = @UserId";

            string productNameQuery =
                "SELECT " +
                    "TransactionId, " +
                    "TransactionDate, " +
                    "STRING_AGG(ProductName, ', ') AS Products, " +
                    "SUM(ActualPricePaid) AS Price " +
                "FROM TransactionInfo " +
                "INNER JOIN TransactionProducts " +
                    "TransactionInfo.TransactionId = TransactionProducts.TransactionId " +
                "INNER JOIN Products" +
                    "Products.ProductId = TransactionProducts.ProductId" +
                "GROUP BY TransactionId " +
                "WHERE TransactionInfo.UserId = @UserId";

            return paymentHistory;
        }
    }
}