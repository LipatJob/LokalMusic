using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Finance
{
    public class ReceiptModel
    {
        public string Username { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string FormattedDate { get { return TransactionDate.ToShortDateString(); } }
        public int TransactionId { get; set; }

        public IList<ReceiptProductItem> Products { get; set; }
    }
}