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
		private const string WITHDRAWN_STATUS = "WITHDRAWN";
		private const string UNPUBLISHED_STATUS = "UNPUBLISHED";

		public DataTable GetProducts()
		{
			string query = @"
SELECT
	[Product].ProductId,
	[Album].AlbumId,
	[Product].ProductName,
	[Product].DateAdded,
	[ArtistInfo].UserId AS ArtistId,
	[ArtistInfo].ArtistName,
	[ProductType].TypeName AS ProductType,
	[ProductStatus].StatusName,
	[AlbumStatus].StatusName AS AlbumStatusName
FROM [Product]
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
	LEFT JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
	INNER JOIN [ProductStatus] ON [ProductStatus].ProductStatusId = [Product].ProductStatusId
	INNER JOIN [ProductType] ON	[ProductType].ProductTypeId = [Product].ProductTypeId
	INNER JOIN [Product] AS [AlbumDetails] ON [AlbumDetails].ProductId = [Album].AlbumId
	INNER JOIN [ProductStatus] AS [AlbumStatus] ON [AlbumStatus].ProductStatusId = [AlbumDetails].ProductStatusId
ORDER BY [Product].DateAdded DESC;
";
			return DbHelper.ExecuteDataTableQuery(query);
		}

        internal void UnlistRepublishProduct(int productId)
        {
            if(GetProductStatus(productId).ToUpper() != WITHDRAWN_STATUS)
            {
				WithdrawItem(productId);
            }
            else
            {
				UnpublishItem(productId);

			}
		}

		private string GetProductStatus(int productId)
        {
			string query = @"
SELECT [ProductStatus].StatusName
FROM [Product] 
	INNER JOIN [ProductStatus] ON [ProductStatus].ProductStatusId = [Product].ProductStatusId
WHERE [Product].ProductId = @ProductId
";
			return (string)DbHelper.ExecuteScalar(query, ("ProductId", productId));

		}

        public void UnpublishItem(int productId)
		{
			ChangeProductStatus(productId, UNPUBLISHED_STATUS);
		}

		public void WithdrawItem(int productId)
		{
			ChangeProductStatus(productId, WITHDRAWN_STATUS);
		}

		public void ChangeProductStatus(int productId, string productStatus)
		{
			string StatusQuery = @"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE ProductId = @ProductId";
			DbHelper.ExecuteNonQuery(
				StatusQuery,
				("ProductStatus", productStatus),
				("ProductId", productId));

			if(IsAlbum(productId))
            {
				string updateQuery = @"
UPDATE [Product]
SET ProductStatusId = (SELECT ProductStatusId
						FROM [ProductStatus]
						WHERE StatusName = @ProductStatus)
WHERE ProductId IN (SELECT TrackId FROM Track WHERE AlbumId = @AlbumId)";

				DbHelper.ExecuteNonQuery(
					updateQuery,
					("ProductStatus", productStatus),
					("AlbumId", productId));
            }
		}

		private bool IsAlbum(int productId)
        {
			string productTypeQuery = @"
SELECT
	[ProductType].TypeName
FROM [Product]
	INNER JOIN [ProductType] ON [ProductType].ProductTypeId = [Product].ProductTypeId
WHERE [Product].ProductId = @ProductId;
";
			string typeName = (string) DbHelper.ExecuteScalar(productTypeQuery, ("ProductId", productId));

			return typeName.ToUpper() == "ALBUM";
		}
	}
}