using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LokalMusic.Account
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SettingsService : System.Web.Services.WebService
    {
        private SettingsRepository repository;
        public SettingsService()
        {
            this.repository = new SettingsRepository();
        }

        [WebMethod]
        public IList<PaymentHistoryItem> GetPaymentHistory()
        {
            return repository.GetPaymentHistory(AuthenticationHelper.UserId);
        }
    }
}
