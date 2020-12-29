using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account
{
    public class LoginPresenter
    {
        private ILoginViewModel viewModel;
        private LoginRepository repository;
        public LoginPresenter(ILoginViewModel view, LoginRepository repository)
        {
            this.viewModel = view;
            this.repository = repository;
        }

        public void CheckAuthentication()
        {
            if (AuthenticationHelper.IsLoggedIn())
            {
                NavigationHelper.Redirect("~/Store/Home");
            }
        }

        public bool Login()
        {

            (bool isLoginSuccessful, int userId) = repository.GetLogin(viewModel);

            if (isLoginSuccessful)
            {
                AuthenticationHelper.UserId = userId;
                NavigationHelper.Redirect("~/Store/Home");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}