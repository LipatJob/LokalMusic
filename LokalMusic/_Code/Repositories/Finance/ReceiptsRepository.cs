using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace LokalMusic._Code.Repositories.Finance
{
	public class ReceiptsRepository
	{
		internal IList<ReceiptListItem> GetReceipts()
		{

			string query = @"
SELECT
	[Transaction].TransactionId,
	[Transaction].TransactionDate,
	[UserInfo].Username,
	(SELECT SUM([TransactionProduct].AmountPaid)
	 FROM TransactionProduct
	 WHERE [TransactionProduct].TransactionId = [Transaction].TransactionId) AS AmountPaid
FROM [Transaction]
LEFT JOIN [UserInfo] ON
	[UserInfo].UserId = [Transaction].UserId
ORDER BY [Transaction].TransactionDate DESC;";

			var receipts = new List<ReceiptListItem>();
			var result = DbHelper.ExecuteDataTableQuery(query);

            foreach (var row in result.AsEnumerable())
            {
				receipts.Add(new ReceiptListItem()
				{
					TransactionId = (int) row["TransactionId"],
					AmountPaid = (decimal) row["AmountPaid"],
					TransactionDate = (DateTime) row["TransactionDate"],
					Username = (string) row["Username"]
				});
            }

			return receipts;
		}

		internal ReceiptModel GetReceiptModel(int receiptId)
		{
			string modelQuery = @"
SELECT
	[Transaction].TransactionId,
	[Transaction].TransactionDate,
	[UserInfo].Username,
	(SELECT SUM([TransactionProduct].AmountPaid)
	 FROM TransactionProduct
	 WHERE [TransactionProduct].TransactionId = [Transaction].TransactionId) AS AmountPaid
FROM [Transaction]
LEFT JOIN [UserInfo] ON
	[UserInfo].UserId = [Transaction].UserId
WHERE [Transaction].TransactionId = @TransactionId;";
			var modelResult = DbHelper.ExecuteDataTableQuery(modelQuery, ("TransactionId", receiptId)).Rows[0];
			var model = new ReceiptModel()
			{
				TransactionId = (int)modelResult["TransactionId"],
				AmountPaid = (decimal)modelResult["AmountPaid"],
				TransactionDate = (DateTime)modelResult["TransactionDate"],
				Username = (string)modelResult["Username"],
				Products = new List<ReceiptProductItem>()
			};

			string productsQuery = @"
SELECT
	[Product].ProductName + ' (' + [ProductType].TypeName+')' AS ProductName,
	[TransactionProduct].AmountPaid
FROM [TransactionProduct]
LEFT JOIN [Product] ON
	[Product].ProductId = [TransactionProduct].ProductId
LEFT JOIN [ProductType] ON
	[Product].ProductTypeId = [ProductType].ProductTypeId
WHERE [TransactionProduct].TransactionId = @TransactionId";
			var productsResult = DbHelper.ExecuteDataTableQuery(productsQuery, ("TransactionId", receiptId));
            foreach (var row in productsResult.AsEnumerable())
            {
				model.Products.Add(new ReceiptProductItem()
				{
					AmountPaid = (decimal) row["AmountPaid"],
					ProductName = (string) row["ProductName"]
				});
            }


			return model;
		}
	}
}