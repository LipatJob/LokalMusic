using LokalMusic._Code.Models.Finance;
using LokalMusic._Code.Repositories.Finance;
using LokalMusic.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Finance
{
    public class ReceiptsPresenter
    {
        private Receipts receipts;
        private ReceiptsRepository repository;

        public ReceiptsPresenter(Receipts receipts, ReceiptsRepository repository)
        {
            this.receipts = receipts;
            this.repository = repository;
        }

        internal static IList<SalesListItem> GetReceipts()
        {
            var repository = new ReceiptsRepository();
            return repository.GetReceipts();
        }

        internal static ReceiptModel GetReceiptModel(int receiptId)
        {
            var repository = new ReceiptsRepository();
            return repository.GetReceiptModel(receiptId);
        }

        internal static SalesHistoryModel GetSalesHistory(DateTime start, DateTime end)
        {
            if(start > end) { return null; }
            var repository = new ReceiptsRepository();
            return repository.GetSalesHistoryModel(start, end);
        }
    }
}