using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
	SUM([OrderInfo].AmountPaid) AS TotalAmountUserPaid
FROM {period}(@StartDate, @EndDate) AS Months
LEFT JOIN [OrderInfo] ON
	[Months].DateStart < = [OrderInfo].OrderDate AND
	[Months].DateEnd > [OrderInfo].OrderDate
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
	SUM([OrderInfo].AmountPaid) - SUM([OrderInfo].AmountPaid) * .15 AS NetSales,
	SUM([OrderInfo].AmountPaid) * .15 AS TotalArtistRevenue,
	SUM([OrderInfo].AmountPaid) AS GrossSales,
	COUNT([OrderInfo].OrderId) AS ProductsSold
FROM [OrderInfo]
WHERE
	[OrderInfo].OrderDate >= @StartDate AND
	[OrderInfo].OrderDate < @EndDate;
";

            var values = DbHelper.ExecuteDataTableQuery(
                query,
                ("StartDate", start),
                ("EndDate", end));
            if (values.Rows.Count == 0)
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
                NetSales = values.Rows[0]["NetSales"],
                GrossSales = values.Rows[0]["GrossSales"],
                TotalArtistRevenue = values.Rows[0]["TotalArtistRevenue"],
                ProductsSold = values.Rows[0]["ProductsSold"],
            };
        }
    }
}