using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using LokalMusic._Code.Views.Account.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LokalMusic._Code.Presenters.Account
{
    public class AccountSettingsPresenter
    {
        private readonly IAccountSettingsViewModel model;
        private readonly SettingsRepository repository;

        public AccountSettingsPresenter(IAccountSettingsViewModel model, SettingsRepository repository)
        {
            this.model = model;
            this.repository = repository;
        }

        public void PageLoad()
        {

            repository.GetAccountDetails(AuthenticationHelper.UserId, model);
        }

        public void ChangePassword()
        {
            repository.UpdatePassword(AuthenticationHelper.UserId, model.NewPassword);
            NavigationHelper.Redirect("~/Account/Settings?PasswordChanged=True");
        }

        public bool CheckOldPassword()
        {
            return repository.CheckPassword(AuthenticationHelper.UserId, model.OldPassword);
        }
    }
}