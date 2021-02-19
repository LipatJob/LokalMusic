using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Finance
{
    public class ArtistPaymentRepository
    {
        public DataTable GetRemainingBalances()
        {
            string query = @"
WITH [UnpaidProducts] AS(
	SELECT
		[ProductOrder].ProductOrderId
	FROM [ProductOrder]
		LEFT JOIN [ProductPayment] ON [ProductPayment].ProductOrderId = [ProductOrder].ProductOrderId
	WHERE [ProductPayment].InvoiceNumber IS NULL
)
SELECT
	MAX([ArtistInfo].ArtistName) AS ArtistName,
	SUM([ProductOrder].ProductPrice) * .85 AS AmountDue
FROM [UnpaidProducts]
	INNER JOIN [ProductOrder] ON [ProductOrder].ProductOrderId = [UnpaidProducts].ProductOrderId
	LEFT JOIN [Product] ON [Product].ProductId = [ProductOrder].ProductId
	LEFT JOIN [Track] ON [Track].TrackId = [ProductOrder].ProductId
	INNER JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [ProductOrder].ProductId)
	INNER JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
GROUP BY
	[ArtistInfo].UserId;
";
            return DbHelper.ExecuteDataTableQuery(query);
        }

        internal DataTable GetRecentPayments()
        {
			string query = @"
SELECT
	[ArtistInfo].ArtistName AS ArtistName,
	[ArtistPayment].Date AS DatePaid,
	[ArtistPayment].TransactionFee AS TransactionFee
FROM [ArtistPayment]
INNER JOIN [ArtistInfo] ON [ArtistInfo].UserId = [ArtistPayment].ArtistId
ORDER BY DatePaid DESC;
";
			return DbHelper.ExecuteDataTableQuery(query);
        }

        public void PayArtists()
        {
			string command = @"
DECLARE @UnpaidProducts TABLE(
	ProductOrderId INT
)

INSERT INTO @UnpaidProducts
	SELECT [ProductOrder].ProductOrderId
	FROM [ProductOrder]
		LEFT JOIN [ProductPayment] ON [ProductPayment].ProductOrderId = [ProductOrder].ProductOrderId
	WHERE [ProductPayment].InvoiceNumber IS NULL

DECLARE @ArtistInvoices TABLE(
	InvoiceNumber INT
);

INSERT INTO ArtistPayment(ArtistId, TransactionFee, Date)
	OUTPUT INSERTED.InvoiceNumber INTO @ArtistInvoices(InvoiceNumber)
SELECT
	MAX([ArtistInfo].UserId) AS ArtistId,
	SUM([ProductOrder].ProductPrice) * .85 AS TransactionFee,
	GETDATE() AS Date
FROM @UnpaidProducts
	INNER JOIN [ProductOrder] ON [ProductOrder].ProductOrderId = [@UnpaidProducts].ProductOrderId
	LEFT JOIN [Product] ON [Product].ProductId =[ProductOrder].ProductId
	LEFT JOIN [Track] ON [Track].TrackId = [ProductOrder].ProductId
	INNER JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [ProductOrder].ProductId)
	INNER JOIN [ArtistInfo] ON [ArtistInfo].UserId = [Album].UserId
GROUP BY
	[ArtistInfo].UserId;


INSERT INTO ProductPayment(InvoiceNumber, ProductOrderId)
SELECT
	[ArtistPayment].InvoiceNumber,
	[ProductOrder].ProductOrderId
FROM @UnpaidProducts
	INNER JOIN [ProductOrder] ON [ProductOrder].ProductOrderId = [@UnpaidProducts].ProductOrderId
	INNER JOIN [Product] ON [Product].ProductId =  [ProductOrder].ProductId
	LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
	INNER JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
	INNER JOIN [ArtistPayment] ON [ArtistPayment].ArtistId = [Album].UserId

";
			DbHelper.ExecuteNonQuery(command);
        }
    }
}