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

            start = EvaluateStartDate(start, period);
            end = EvaluateEndDate(end, period);

            if(DateRangeTooLarge(start, end, period))
            {
                return null;
            }

            return new
            {
                figures = GetFiguresValues(start, end),
                chart = GetChartValues(start, end, period)
            };
        }

        private bool DateRangeTooLarge(DateTime start, DateTime end, string period)
        {
            TimeSpan span = end - start;
            const int MONTH_DAYS = 30;
            const int WEEK_DAYS = 7;
            const int YEAR_DAYS = 365;
            const int MAX_COUNT = 30;

            if (period == MONTHLY)
            {
                if (span.TotalDays > MONTH_DAYS * MAX_COUNT)
                {
                    return true;
                }
            }
            else if (period == WEEKLY)
            {
                if (span.TotalDays > WEEK_DAYS * MAX_COUNT)
                {
                    return true;
                }
            }
            else if (period == YEARLY)
            {
                if (span.TotalDays > YEAR_DAYS * MAX_COUNT)
                {
                    return true;
                }
            }

            return false;
        }

        private DateTime EvaluateStartDate(DateTime start, string period)
        {
            if(period == MONTHLY)
            {
                return new DateTime(start.Year, start.Month, 1, 0, 0, 0);
            }
            else if(period == WEEKLY)
            {
                return StartOfWeek(start, DayOfWeek.Sunday);
            }
            else if(period == YEARLY)
            {
                return new DateTime(start.Year, 1, 1, 0, 0, 0);
            }

            return start;
        }

        private DateTime StartOfWeek(DateTime start, DayOfWeek startOfWeek)
        {
            int diff = (7 + (start.DayOfWeek - startOfWeek)) % 7;
            return start.AddDays(-1 * diff).Date;
        }

        private DateTime EvaluateEndDate(DateTime end, string period)
        {
            if (period == MONTHLY)
            {
                return new DateTime(end.Year, end.Month, DateTime.DaysInMonth(end.Year, end.Month));
            }
            else if (period == WEEKLY)
            {
                return EndOfWeek(end);
            }
            else if (period == YEARLY)
            {
                return new DateTime(end.Year, 12, DateTime.DaysInMonth(end.Year, 12));
            }

            return end;
        }

        private DateTime EndOfWeek(DateTime end)
        {
            return StartOfWeek(end, DayOfWeek.Sunday).AddDays(6);
        }

        private object GetChartValues(DateTime start, DateTime end, string period)
        {
            string query =
$@"
SELECT
	CONVERT(VARCHAR(20), [Months].DateStart, 107) + ' - ' +  CONVERT(VARCHAR(20), MAX([Months].DateEnd), 107) AS Date,
	COALESCE(SUM([OrderInfo].AmountPaid), 0) AS TotalAmountUserPaid
FROM {period}(@StartDate, @EndDate) AS Months
LEFT JOIN [OrderInfo] ON
	[Months].DateStart < = [OrderInfo].OrderDate AND
	[Months].DateEnd > [OrderInfo].OrderDate
WHERE [Months].DateStart <= @EndDate
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
                labels.Add(((string) row["Date"]));
                data.Add(row.IsNull("TotalAmountUserPaid") ? 0 : (decimal)row["TotalAmountUserPaid"]);
            }

            string startString = start.ToString();
            string endString = end.ToString();
            return new
            {
                labels,
                data,
                startString,
                endString
            };
        }

        private object GetFiguresValues(DateTime start, DateTime end)
        {

            string query =
@"
SELECT
	COALESCE(SUM([OrderInfo].AmountPaid) - SUM([OrderInfo].AmountPaid) * .15, 0) AS NetSales,
	COALESCE(SUM([OrderInfo].AmountPaid) * .15, 0) AS TotalArtistRevenue,
	COALESCE(SUM([OrderInfo].AmountPaid), 0) AS GrossSales,
	COALESCE(COUNT([OrderInfo].OrderId), 0) AS ProductsSold
FROM [OrderInfo]
WHERE
	[OrderInfo].OrderDate >= @StartDate AND
	[OrderInfo].OrderDate < @EndDate;
";

            var values = DbHelper.ExecuteDataTableQuery(
                query,
                ("StartDate", start),
                ("EndDate", end));

            string startString = start.ToString();
            string endString = end.ToString();
            return new
            {
                NetSales = values.Rows[0]["NetSales"],
                GrossSales = values.Rows[0]["GrossSales"],
                TotalArtistRevenue = values.Rows[0]["TotalArtistRevenue"],
                ProductsSold = values.Rows[0]["ProductsSold"],
                startString,
                endString
            };
        }
    }
}