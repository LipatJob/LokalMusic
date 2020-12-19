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
        private ILoginView view;
        private LoginRepository repository;
        public LoginPresenter(ILoginView view, LoginRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Login()
        {
            string userId = ""; //TODO: Get UserId from database
            bool isLoginSuccessful = false; //TODO: Check 

            if (isLoginSuccessful)
            {
                SessionHelper.SetLoginSession(userId);
                view.RedirectToHomePage();
            }
            else
            {
                view.ShowLoginErrorMessage();
            }
        }
    }
}