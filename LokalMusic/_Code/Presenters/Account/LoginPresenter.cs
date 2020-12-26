using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic.Code.Repositories.Account;
using LokalMusic.Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic.Code.Presenters.Account
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

        public bool Login()
        {

            (bool isLoginSuccessful, int userId) = repository.GetLogin(viewModel);

            if (isLoginSuccessful)
            {
                AuthenticationHelper.UserId = userId;
                NavigationHelper.Redirect("~");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}