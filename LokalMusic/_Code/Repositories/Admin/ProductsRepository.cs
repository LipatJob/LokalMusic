using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LokalMusic._Code.Repositories.Admin
{
	public class ProductsRepository
	{
		private const string WITHDRAWN_STATUS = "WITHDRAWN";
		private const string PUBLISHED_STATUS = "PUBLISHED";

		public IList<ProductItem> GetProducts()
		{
			string query = @"
SELECT
	[Product].ProductId,
	[Album].AlbumId,
	[Product].ProductName,
	[Product].DateAdded,
	[ArtistInfo].UserId AS ArtistId,
	[ArtistInfo].ArtistName,
	[ProductType].TypeName,
	[ProductStatus].StatusName
	
FROM [Product]
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	INNER JOIN [ProductStatus] ON [ProductStatus].ProductStatusId = [Product].ProductStatusId
	INNER JOIN [ProductType] ON	[ProductType].ProductTypeId = [Product].ProductTypeId
ORDER BY [Product].DateAdded DESC;
";
			return DbHelper.ExecuteDataTableQuery(query).AsEnumerable().Select((row) =>
			{
				return new ProductItem()
				{
					AlbumId = row.IsNull("AlbumId") ? null : (int?)row["AlbumId"],
					ProductId = (int)row["ProductId"],
					ProductName = (string)row["ProductName"],
					ArtistName = (string)row["ArtistName"],
					DateListed = (DateTime)row["DateAdded"],
					ProductType = (string)row["TypeName"],
					ProductStatus = (string)row["StatusName"],
					ArtistId = (int)row["ArtistId"]
				};
			}).ToList();
		}

		public void RepublishItem(int productId)
		{
			ChangeProductStatus(productId, PUBLISHED_STATUS);
		}

		public void WithdrawItem(int productId)
		{
			ChangeProductStatus(productId, WITHDRAWN_STATUS);
		}

		public void ChangeProductStatus(int productId, string productStatus)
		{
			string query = @"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE ProductId = @ProductId";
			DbHelper.ExecuteNonQuery(
				query,
				("ProductStatus", productStatus),
				("ProductId", productId));
		}
	}
}