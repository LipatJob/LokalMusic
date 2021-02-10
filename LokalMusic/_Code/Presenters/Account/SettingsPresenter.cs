using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Models.Finance;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LokalMusic._Code.Presenters.Account
{
    public class SettingsPresenter
    {
        public static List<ReceiptListItem> GetPaymentHistory()
        {
            SettingsRepository repository = new SettingsRepository();
            return repository.GetPaymentHistory(AuthenticationHelper.UserId).ToList();
        }

        public static ReceiptModel GetReceiptModel(int receiptId)
        {
            SettingsRepository repository = new SettingsRepository();
            var model = repository.GetReceiptModel(receiptId);
            if(model.Username != AuthenticationHelper.Username)
            {
                return null;
            }
            return model;
        }
    }
}