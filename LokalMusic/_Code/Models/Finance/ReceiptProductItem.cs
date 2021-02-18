using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Finance
{
    public class ReceiptProductItem
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string FormattedPrice { get { return "₱" + ProductPrice.ToString("#,##0.00"); } }

    }
}