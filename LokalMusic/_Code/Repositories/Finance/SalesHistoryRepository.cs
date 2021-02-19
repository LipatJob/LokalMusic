using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace LokalMusic._Code.Repositories.Finance
{
	public class SalesHistoryRepository
	{

		public SalesHistoryModel GetSalesHistoryModel(DateTime dateStart, DateTime dateEnd)
        {

			return new SalesHistoryModel {
				MostBoughtProduct = GetMostBoughtProduct(dateStart, dateEnd),
				LeastBoughtProduct = GetLeastBoughtProduct(dateStart, dateEnd),
				SalesItems = GetSalesListItem(dateStart, dateEnd)
			};
        }

		private IList<SalesListItem> GetSalesListItem(DateTime dateStart, DateTime dateEnd)
		{
			string query = @"
SELECT
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].FirstName  + ' ' +[UserInfo].LastName AS Name,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
WHERE
	[OrderInfo].OrderDate BETWEEN @StartDate AND @EndDate
ORDER BY [OrderInfo].OrderDate ASC;
";

			var receipts = new List<SalesListItem>();
			var result = DbHelper.ExecuteDataTableQuery(
				query,
				("StartDate", dateStart),
				("EndDate", dateEnd));

			foreach (var row in result.AsEnumerable())
			{
				receipts.Add(new SalesListItem()
				{
					OrderId = (int)row["OrderId"],
					AmountPaid = (decimal)row["AmountPaid"],
					OrderDate = (DateTime)row["OrderDate"],
					Name = (string)row["Name"]
				});
			}

			return receipts;
		}

		private SalesProductModel GetMostBoughtProduct(DateTime dateStart, DateTime dateEnd)
        {
			string query = @"
WITH MostBoughtProduct AS (
	SELECT TOP 1
		MAX([ProductOrder].ProductId) AS ProductId,
		COUNT([ProductOrder].ProductPrice) AS SoldCount
	FROM [ProductOrder]
	WHERE [ProductOrder].OrderDate BETWEEN @StartDate AND @EndDate
	GROUP BY [ProductOrder].ProductId
	ORDER BY SoldCount DESC
)
SELECT
	[ArtistInfo].ArtistName,
	[Product].ProductName,
	[FileInfo].[FileName] AS AlbumCover,
	[MostBoughtProduct].SoldCount,
	[ProductType].TypeName
FROM [Product]
	INNER JOIN [MostBoughtProduct] ON [MostBoughtProduct].ProductId = [Product].ProductId
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	LEFT JOIN [FileInfo] ON [FileInfo].FileId = [Album].AlbumCoverID
	INNER JOIN [ProductType] ON [ProductType].ProductTypeId = [Product].ProductTypeId;
";
			var result = DbHelper.ExecuteDataTableQuery(
				query,
				("StartDate", dateStart),
				("EndDate", dateEnd));
			if(result.Rows.Count == 0)
            {
				return null;
            }

			return new SalesProductModel
			{
				AlbumCover = (string) result.Rows[0]["AlbumCover"],
				ArtistName = (string) result.Rows[0]["ArtistName"],
				ProductName = (string) result.Rows[0]["ProductName"],
				ProductType= (string)result.Rows[0]["TypeName"],

			};
        }

		private SalesProductModel GetLeastBoughtProduct(DateTime dateStart, DateTime dateEnd)
		{
			string query = @"
WITH MostBoughtProduct AS (
	SELECT TOP 1
		MAX([ProductOrder].ProductId) AS ProductId,
		COUNT([ProductOrder].ProductPrice) AS SoldCount
	FROM [ProductOrder]
	WHERE [ProductOrder].OrderDate BETWEEN @StartDate AND @EndDate
	GROUP BY [ProductOrder].ProductId
	ORDER BY SoldCount ASC
)
SELECT
	[ArtistInfo].ArtistName,
	[Product].ProductName,
	[FileInfo].[FileName] AS AlbumCover,
	[MostBoughtProduct].SoldCount,
	[ProductType].TypeName
FROM [Product]
	INNER JOIN [MostBoughtProduct] ON [MostBoughtProduct].ProductId = [Product].ProductId
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	LEFT JOIN [FileInfo] ON [FileInfo].FileId = [Album].AlbumCoverID
	INNER JOIN [ProductType] ON [ProductType].ProductTypeId = [Product].ProductTypeId;
";
			var result = DbHelper.ExecuteDataTableQuery(
				query,
				("StartDate", dateStart),
				("EndDate", dateEnd));
			if (result.Rows.Count == 0)
			{
				return null;
			}

			return new SalesProductModel
			{
				AlbumCover = (string)result.Rows[0]["AlbumCover"],
				ArtistName = (string)result.Rows[0]["ArtistName"],
				ProductName = (string)result.Rows[0]["ProductName"],
				ProductType = (string)result.Rows[0]["TypeName"],
			};
		}



		internal IList<SalesListItem> GetReceipts()
		{
			string query = @"
SELECT
	[OrderInfo].OrderId,
	[OrderInfo].OrderDate,
	[UserInfo].Username,
	[OrderInfo].AmountPaid
FROM [OrderInfo]
	LEFT JOIN [UserInfo] ON [UserInfo].UserId = [OrderInfo].CustomerId
ORDER BY [OrderInfo].OrderDate ASC;
";

			var receipts = new List<SalesListItem>();
			var result = DbHelper.ExecuteDataTableQuery(query);

            foreach (var row in result.AsEnumerable())
            {
				receipts.Add(new SalesListItem()
				{
					OrderId = (int) row["OrderId"],
					AmountPaid = (decimal) row["AmountPaid"],
					OrderDate = (DateTime) row["OrderDate"],
					Name = (string) row["Username"]
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
	[UserInfo].FirstName  + ' ' +[UserInfo].LastName AS Name,
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
				Name = (string)modelResult["Name"],
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