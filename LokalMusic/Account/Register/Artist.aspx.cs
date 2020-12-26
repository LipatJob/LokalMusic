using LokalMusic._Code.Presenters.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account.Register
{
    public partial class Artist : System.Web.UI.Page, IRegisterArtistViewModel
    {
        private RegisterArtistPresenter presenter;
        public Artist()
        {
            presenter = new RegisterArtistPresenter(this, new RegisterArtistRepository());
        }
        public string ArtistName { get => ArtistNameTxt.Text; set => throw new NotImplementedException(); }
        public string Email { get => EmailTxt.Text; set => throw new NotImplementedException(); }
        public string Username { get => UsernameTxt.Text; set => throw new NotImplementedException(); }
        public string Password { get => PasswordTxt.Text; set => throw new NotImplementedException(); }
        public string ConfirmPassword { get => ConfirmPasswordTxt.Text; set => throw new NotImplementedException(); }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ArtistNameTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                presenter.Register();
            }
        }

        protected void UsernameTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (Username.Length < 5)
            {
                validator.ErrorMessage = "Username must have at least 5 characters";
                args.IsValid = false;
            }
            else if (presenter.IsUsernameUnique() == false)
            {
                validator.ErrorMessage = "That username has already been taken";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void EmailTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (Email.Length == 0)
            {
                validator.ErrorMessage = "This is a required field";
                args.IsValid = false;
            }
            if (IsValidEmailFormat(Email) == false)
            {
                validator.ErrorMessage = "Please enter a valid email";
                args.IsValid = false;
            }
            else if (presenter.IsEmailUnique() == false)
            {
                validator.ErrorMessage = "Another account has already been associated with the email";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        private bool IsValidEmailFormat(string email)
        {
            // source: http://thedailywtf.com/Articles/Validating_Email_Addresses.aspx
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }

        protected void PasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (Password.Length < 5)
            {
                validator.ErrorMessage = "Password must be at least 5 characters";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ConfirmPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            if (Password.Length < 5)
            {
                validator.ErrorMessage = "Password must be at least 5 characters";
                args.IsValid = false;
            }
            else if (ConfirmPassword != Password)
            {
                validator.ErrorMessage = "Confrim Password must match with Password";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void TosCbCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = TosCb.Checked;
        }
    }
}