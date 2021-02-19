using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using LokalMusic._Code.Views.Account.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account.Settings
{
    public partial class Default : System.Web.UI.Page, IAccountSettingsViewModel
    {
        AccountSettingsPresenter presenter;
        public Default()
        {
            presenter = new AccountSettingsPresenter(this, new SettingsRepository());

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.RedirectReturnAddress("~/Account/Login");
            }
            if(!Page.IsPostBack)
            {
                presenter.PageLoad();
            }
            if (IsPasswordChanged())
            {
                ShowPasswordChangedMessage();
            }
        }

        public string Username { get => UsernameTxt.Text; set => UsernameTxt.Text = value; }
        public string Email { get => EmailTxt.Text; set => EmailTxt.Text = value; }
        public string OldPassword { get => OldPasswordTxt.Text; }
        public string NewPassword { get => NewPasswordTxt.Text; }
        public string ConfrimNewPassword { get => ConfirmNewPasswordTxt.Text; }
        public string FirstName { get => FirstNameTxt.Text; set => FirstNameTxt.Text = value; }
        public string LastName { get => LastNameTxt.Text; set => LastNameTxt.Text = value; }

        private bool IsPasswordChanged()
        {
            return Request.QueryString["PasswordChanged"] == "True";
        }

        private void ShowPasswordChangedMessage()
        {
            changePasswordSuccessAlert.Visible = true;
            changePasswordSuccessMessage.InnerText = "Successfully changed Password";
        }

        protected void OldPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(OldPassword),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => presenter.CheckOldPassword(),
                    errorMessage: "Please check your old password")
                .Validate();
        }


        protected void NewPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ValidUtils.CreatePasswordValidator((IValidator)source, args, NewPassword).Validate();
        }


        protected void ConfirmNewPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(ConfrimNewPassword),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => NewPassword == ConfrimNewPassword,
                    errorMessage: "Password confirmation does not match")
                .Validate();
        }



        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                presenter.ChangePassword();
            }
        }

        protected void btnSubmitAccountDetails_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                presenter.ChangeAccountDetails();
            }
        }
    }
}