using LokalMusic._Code.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Finance
{
    public class ReceiptsRepository
    {
        internal IList<ReceiptListItem> GetReceipts()
        {
            return new List<ReceiptListItem>
            {
                new ReceiptListItem{ TransactionId=1, AmountPaid=100, TransactionDate=DateTime.Now, Username="JobLipat" }
            };
        }

        internal ReceiptModel GetReceiptModel(int receiptId)
        {
            return new ReceiptModel() {
                TransactionId = 1,
                AmountPaid = 100,
                TransactionDate = DateTime.Now,
                Username = "JobLipat",
                Products = new List<ReceiptProductItem>()
                {
                    new ReceiptProductItem(){AmountPaid=100, ProductName="Product 1"},
                    new ReceiptProductItem(){AmountPaid=101, ProductName="Product 2"},
                }
            };
        }
    }
}