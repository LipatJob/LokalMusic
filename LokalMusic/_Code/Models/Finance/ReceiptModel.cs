using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Finance
{
    public class ReceiptModel
    {
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string FormattedDate { get { return OrderDate.ToShortDateString(); } }
        public int OrderId { get; set; }
        public IList<ReceiptProductItem> Products { get; set; }
    }
}