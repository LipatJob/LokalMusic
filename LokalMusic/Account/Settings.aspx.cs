using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account
{
    public partial class Settings : System.Web.UI.Page, ISettingsViewModel
    {
        SettingsPresenter presenter;
        public Settings()
        {
            presenter = new SettingsPresenter(this, new SettingsRepository());
        }

        public string Username { get => UsernameTxt.Text; set => UsernameTxt.Text = value; }
        public string Email { get => EmailTxt.Text; set => EmailTxt.Text = value; }
        public string OldPassword { get => OldPasswordTxt.Text; }
        public string NewPassword { get => NewPasswordTxt.Text; }
        public string ConfrimNewPassword { get => ConfirmNewPasswordTxt.Text; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.PageLoad();
            
            if(IsPasswordChanged())
            {
                ShowPasswordChangedMessage();
            }
        }

        private bool IsPasswordChanged()
        {
            return Request.QueryString["PasswordChanged"] == "True";
        }
        private void ShowPasswordChangedMessage()
        {
            successAlert.Visible = true;
            alertMessage.InnerText = "Successfully changed Password";
        }

        protected void OldPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if(OldPassword.Length == 0)
            {
                validator.ErrorMessage = "This is a required field";
                args.IsValid = false;
            }
            else if(presenter.CheckOldPassword() == false)
            {
                validator.ErrorMessage = "Please check your old password";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void NewPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (NewPassword.Length == 0)
            {
                validator.ErrorMessage = "This is a required field";
                args.IsValid = false;
            }
            else if (NewPassword.Length < 5)
            {
                validator.ErrorMessage = "Password must be at least 5 characters";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ConfirmNewPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (ConfrimNewPassword.Length == 0)
            {
                validator.ErrorMessage = "This is a required field";
                args.IsValid = false;
            }
            else if (NewPassword != ConfrimNewPassword)
            {
                validator.ErrorMessage = "Password confirmation does not match";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
            
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                presenter.ChangePassword();
            }
        }
    }
}