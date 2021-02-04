﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LokalMusic._Code.Repositories.Admin
{
	public class ProductsRepository
	{
		private const string UNLISTED_STATUS = "UNLISTED";
		private const string LISTED_STATUS = "LISTED";

		public IList<ProductItem> GetProducts()
		{
			string query = @"
SELECT
	[Product].ProductId,
	[Album].AlbumId,
	[Product].ProductName,
	[Product].DateAdded,
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
					ProductStatus = (string)row["StatusName"]
				};
			}).ToList();
		}

		public void RelistItem(int productId)
		{
			ChangeProductStatus(productId, LISTED_STATUS);
		}

		public void UnlistItem(int productId)
		{
			ChangeProductStatus(productId, UNLISTED_STATUS);
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