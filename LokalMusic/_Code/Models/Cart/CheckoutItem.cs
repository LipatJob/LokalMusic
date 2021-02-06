using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Cart
{
    public class CheckoutItem
    {
        public CheckoutItem()
        {
        }

        public CheckoutItem(int productId, string productName, decimal price, string productType)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            ProductType = productType;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public string ProductType { get; set; }

    }
}