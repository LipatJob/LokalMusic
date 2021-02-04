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
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].Username,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
ORDER BY [OrderInfo].OrderDate DESC;
";

			var receipts = new List<ReceiptListItem>();
			var result = DbHelper.ExecuteDataTableQuery(query);

            foreach (var row in result.AsEnumerable())
            {
				receipts.Add(new ReceiptListItem()
				{
					OrderId = (int) row["OrderId"],
					AmountPaid = (decimal) row["AmountPaid"],
					OrderDate = (DateTime) row["OrderDate"],
					Username = (string) row["Username"]
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
				Username = (string)modelResult["Username"],
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
					ProductPrice = (decimal) row["ProductPrice"],
					ProductName = (string) row["ProductName"]
				});
            }


			return model;
		}
	}
}