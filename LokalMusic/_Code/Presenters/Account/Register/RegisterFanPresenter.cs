using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account.Register
{
    public class RegisterFanPresenter
    {
        private RegisterFanRepository repository;
        private IRegisterFanViewModel viewModel;

        public RegisterFanPresenter(IRegisterFanViewModel viewModel, RegisterFanRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void Register()
        {
            repository.RegisterFan(viewModel);
            NavigationHelper.Redirect("~/Account/Login");
        }

        public bool IsUsernameUnique()
        {
            return repository.IsUsernameUnique(viewModel.Username);
        }

        public bool IsEmailUnique()
        {
            return repository.IsEmailUnique(viewModel.Email);
        }
    }
}