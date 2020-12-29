using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account
{
    public class PaymentHistoryItem
    {
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string ItemsPurchased { get; set; }
        public decimal Amount { get; set; }
        public string FormattedDate { get { return TransactionDate.ToString("MM/dd/yyyy h:mm tt"); } }

        
    }
}