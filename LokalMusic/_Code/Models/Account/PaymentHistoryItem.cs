using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account
{
    public class PaymentHistoryItem
    {
        public int TransactionId { get; set; }
        public string Date { get; set; }

        public string ItemsPurchased { get; set; }
        public decimal Amount { get; set; }
        
    }
}