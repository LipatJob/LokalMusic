using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Finance
{
    public class SalesListItem
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string FormattedDate { get { return OrderDate.ToString("MMM dd, yyyy"); } }
        public string FormattedAmount { get { return AmountPaid.ToString("#,##0.00"); } }

    }
}