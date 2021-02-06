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
    public class ProfileSettingsPresenter
    {
        private readonly IProfileSettingsViewModel viewModel;
        private readonly SettingsRepository repository;

        public ProfileSettingsPresenter(IProfileSettingsViewModel viewModel, SettingsRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void PageLoad()
        {
            repository.GetProfileDetails(AuthenticationHelper.UserId, viewModel);
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