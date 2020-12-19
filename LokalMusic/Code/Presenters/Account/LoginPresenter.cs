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
        private ILoginView view;
        private LoginRepository repository;
        public LoginPresenter(ILoginView view, LoginRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Login()
        {
            bool isLoginSuccessful = false; 

            if(isLoginSuccessful)
            {
                view.RedirectToHomePage();
            }
            else
            {
                view.ShowLoginErrorMessage();
            }
        }
    }
}