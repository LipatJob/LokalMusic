using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (AuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.Redirect("~/Account/Login");
            }
            repository.GetUserDetails(AuthenticationHelper.UserId, viewModel);
        }

        public void ChangePassword()
        {
            repository.UpdatePassword(AuthenticationHelper.UserId, viewModel.NewPassword);
            NavigationHelper.Redirect("~/Account/Settings?PasswordChanged=True");
        }

        public bool CheckOldPassword()
        {
            return repository.CheckPassword(AuthenticationHelper.UserId, viewModel.OldPassword);
        }

        public static List<PaymentHistoryItem> GetPaymentHistory()
        {
            SettingsRepository repository = new SettingsRepository();
            return repository.GetPaymentHistory(AuthenticationHelper.UserId).ToList();
        }

        public void UpdateProfilePicture()
        {
            repository.ChangeProfilePicture(AuthenticationHelper.UserId, viewModel.UploadedProfilePicture);
            NavigationHelper.Redirect("~/Account/Settings?ProfileImageChanged=True");
        }

        internal void UpdateBio()
        {
            repository.UpdateArtistBio(AuthenticationHelper.UserId, viewModel.ArtistBio);
            NavigationHelper.Redirect("~/Account/Settings?ArtistBioChanged=True");
        }
    }
}