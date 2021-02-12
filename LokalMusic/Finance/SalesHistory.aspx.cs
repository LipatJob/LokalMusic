using LokalMusic._Code.Models.Finance;
using LokalMusic._Code.Presenters.Finance;
using LokalMusic._Code.Repositories.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Finance
{
    public partial class SalesHistory : System.Web.UI.Page
    {
        private SalesHistoryPresenter presenter;
        public SalesHistory()
        {
            presenter = new SalesHistoryPresenter(this, new SalesHistoryRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static SalesHistoryModel GetSalesHistory(DateTime startDate, DateTime endDate)
        {
            return SalesHistoryPresenter.GetSalesHistory(startDate, endDate);
        }

        [WebMethod]
        public static ReceiptModel GetReceipt(int receiptId)
        {
            return SalesHistoryPresenter.GetReceiptModel(receiptId);
        }
    }
}