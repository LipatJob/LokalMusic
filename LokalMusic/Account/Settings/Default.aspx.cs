using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account.Settings
{
    public partial class Default : System.Web.UI.Page, ISettingsViewModel
    {
        SettingsPresenter presenter;
        public Default()
        {
            presenter = new SettingsPresenter(this, new SettingsRepository());

        }
        protected void Page_Load(object sender, EventArgs e)
        {
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
        public string ProfileImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ArtistBio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ArtistName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HttpPostedFile UploadedProfilePicture => throw new NotImplementedException();

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
    }
}