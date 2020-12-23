using LokalMusic._Code.Helpers;
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
        private ILoginViewModel view;
        private LoginRepository repository;
        public LoginPresenter(ILoginViewModel view, LoginRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Login()
        {

            (bool isLoginSuccessful, int userId) = repository.GetLogin(view);

            if (isLoginSuccessful)
            {
                AuthenticationHelper.UserId = userId;
                NavigationHelper.Redirect("~");
            }
            else
            {
            }
        }
    }
}