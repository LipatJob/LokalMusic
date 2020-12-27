using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account
{
    public class SettingsPresenter
    {
        private readonly ISettingsViewModel viewModel;
        private readonly SettingsRepository repository;

        public SettingsPresenter(ISettingsViewModel viewModel, SettingsRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void PageLoad()
        {
            if(AuthenticationHelper.IsLoggedIn() == false)
            {
                NavigationHelper.Redirect("~/Account/Login");
            }
            repository.GetUserDetails(AuthenticationHelper.UserId, viewModel);
        }

        public void ChangePassword()
        {
            repository.UpdatePassword(AuthenticationHelper.UserId, viewModel.NewPassword);
        }

        public bool CheckOldPassword()
        {
            return repository.CheckPassword(AuthenticationHelper.UserId, viewModel.OldPassword);
        }

    }

}