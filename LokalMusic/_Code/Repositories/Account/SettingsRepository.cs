using LokalMusic._Code.Models.Account;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
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

            string productNameQuery = @"
SELECT
	[Transactions].TransactionId AS TransactionId,
	MAX(TransactionDate) AS TransactionDate,
	STRING_AGG(ProductName, ', ') AS ItemsPurchased,
	SUM([Transactions].ActualAmountPaid) AS Amount
FROM [Transactions]
	INNER JOIN TransactionProducts ON
		[Transactions].TransactionId = [TransactionProducts].TransactionId
	INNER JOIN Product ON
		[Product].ProductId = [TransactionProducts].ProductId
WHERE [Transactions].UserId = @UserId
GROUP BY [Transactions].TransactionId
ORDER BY TransactionDate DESC;
";
            var result = DbHelper.ExecuteDataTableQuery(productNameQuery, ("UserId", userId));
            foreach (DataRow row in result.Rows)
            {
                paymentHistory.Add(new PaymentHistoryItem()
                {
                    TransactionId = (int)row["TransactionId"],
                    TransactionDate = (DateTime)row["TransactionDate"],
                    ItemsPurchased = (string) row["ItemsPurchased"],
                    Amount = (decimal) row["Amount"]
                });
            }
            return paymentHistory;
        }
    }
}