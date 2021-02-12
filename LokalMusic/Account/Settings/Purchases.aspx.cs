using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Models.Finance;
using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account.Settings
{
    public partial class Purchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<SalesListItem> GetPaymentHistory()
        {
            return SettingsPresenter.GetPaymentHistory();
        }

        [WebMethod]
        public static ReceiptModel GetReceipt(int receiptId)
        {
            return SettingsPresenter.GetReceiptModel(receiptId);
        }
    }
}