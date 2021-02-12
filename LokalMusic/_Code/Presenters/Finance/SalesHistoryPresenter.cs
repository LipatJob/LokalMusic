using LokalMusic._Code.Models.Finance;
using LokalMusic._Code.Repositories.Finance;
using LokalMusic.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Finance
{
    public class SalesHistoryPresenter
    {
        private SalesHistory receipts;
        private SalesHistoryRepository repository;

        public SalesHistoryPresenter(SalesHistory receipts, SalesHistoryRepository repository)
        {
            this.receipts = receipts;
            this.repository = repository;
        }

        internal static IList<SalesListItem> GetReceipts()
        {
            var repository = new SalesHistoryRepository();
            return repository.GetReceipts();
        }

        internal static ReceiptModel GetReceiptModel(int receiptId)
        {
            var repository = new SalesHistoryRepository();
            return repository.GetReceiptModel(receiptId);
        }

        internal static SalesHistoryModel GetSalesHistory(DateTime start, DateTime end)
        {
            if(start > end) { return null; }
            var repository = new SalesHistoryRepository();
            return repository.GetSalesHistoryModel(start, end);
        }
    }
}