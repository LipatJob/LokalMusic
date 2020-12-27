using LokalMusic._Code.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account
{
    public class SettingsRepository
    {
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