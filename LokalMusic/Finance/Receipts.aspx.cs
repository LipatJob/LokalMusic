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
    public partial class Receipts : System.Web.UI.Page
    {
        private ReceiptsPresenter presenter;
        public Receipts()
        {
            presenter = new ReceiptsPresenter(this, new ReceiptsRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static IList<ReceiptListItem> GetReceipts()
        {
            return ReceiptsPresenter.GetReceipts();
        }

        [WebMethod]
        public static ReceiptModel GetReceipt(int receiptId)
        {
            return ReceiptsPresenter.GetReceiptModel(receiptId);
        }
    }
}