﻿using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;

namespace LokalMusic.Webforms.Account
{
    public partial class Login : System.Web.UI.Page, ILoginViewModel
    {
        private LoginPresenter presenter;
        public Login()
        {
            presenter = new LoginPresenter(this, new LoginRepository());
        }

        public string Email { get { return EmailTxt.Text; } }
        public string Password { get { return PasswordTxt.Text; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.CheckAuthentication();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool success = presenter.Login();
            if (success == false)
            {
                loginCv.IsValid = false;
                loginCv.ErrorMessage = "Please check you email and password";
            }
        }
    }
}