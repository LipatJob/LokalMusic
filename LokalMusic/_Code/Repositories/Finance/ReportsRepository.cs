using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Finance
{
	public class ReportsRepository
	{
		public const string MONTHLY = "GetMonthsBetween";
		public const string YEARLY = "GetYearsBetween";
		public const string WEEKLY = "GetWeeksBetween";

		public object GetReport(DateTime start, DateTime end, string period)
		{
			if (new[] { WEEKLY, MONTHLY, YEARLY }.Contains(period) == false) { return null; }





			return new
			{
				chart = GetChartValues(start, end, period),
				figures = GetFiguresValues(start, end)
			};
		}


		private object GetChartValues(DateTime start, DateTime end, string period)
		{
			string query =
$@"
SELECT
	[Months].DateStart AS Date,
	SUM([Transaction].ActualAmountPaid) AS TotalAmountUserPaid
FROM {period}(@StartDate, @EndDate) AS Months
LEFT JOIN [Transaction] ON
	[Months].DateStart < = [Transaction].TransactionDate AND
	[Months].DateEnd > [Transaction].TransactionDate
GROUP BY [Months].DateStart
";
			List<string> labels = new List<string>();
			List<decimal> data = new List<decimal>();
			var values = DbHelper.ExecuteDataTableQuery(
				query,
				("StartDate", start),
				("EndDate", end));

			foreach (var row in values.AsEnumerable())
			{
				labels.Add(((DateTime)row["Date"]).ToShortDateString());
				data.Add(row.IsNull("TotalAmountUserPaid") ? 0 : (decimal)row["TotalAmountUserPaid"]);
			}
			return new
			{
				labels,
				data
			};
		}

		private object GetFiguresValues(DateTime start, DateTime end)
		{
			string query =
@"
SELECT
	SUM(ActualAmountPaid) AS NetSales
FROM [Transaction]
WHERE
	TransactionDate >= @StartDate AND
	TransactionDate < @EndDate
";
			var values = DbHelper.ExecuteDataTableQuery(
				query,
				("StartDate", start),
				("EndDate", end));
			if(values.Rows.Count == 0)
			{
				return new
				{
					NetSales = 0,
					GrossSales = 0,
					TotalArtistRevenue = 0,
					ProductsSold = 0,
				};
			}

			return new
			{
				NetSales = values.Rows[0].IsNull("NetSales") ? 0 : values.Rows[0]["NetSales"],
				GrossSales = 0,
				TotalArtistRevenue = 0,
				ProductsSold = 0,
			};
		}
	}


}