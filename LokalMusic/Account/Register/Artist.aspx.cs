using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Linq;
using System.Text.RegularExpressions;
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

        public string FirstName { get => FirstNameTxt.Text; }
        public string LastName { get => LastNameTxt.Text; }

        public string ArtistName { get => ArtistNameTxt.Text; }
        public string Email { get => EmailTxt.Text; }
        public string Username { get => UsernameTxt.Text; }
        public string Password { get => PasswordTxt.Text; }
        public string ConfirmPassword { get => ConfirmPasswordTxt.Text; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ArtistNameTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(ArtistName),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => ArtistName.Length >= 3,
                    errorMessage: "Artist name must be at least 3 letters long")
                .Validate();
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
            ValidUtils.CreateUsernameValidator((IValidator)source, args, Username)
                .AddRule(
                    rule: () => presenter.IsUsernameUnique(),
                    errorMessage: "That username has already been taken")
                .Validate();
        }

        protected void EmailTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(Email),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => IsValidEmailFormat(Email),
                    errorMessage: "Please enter a valid email")
                .AddRule(
                    rule: () => presenter.IsEmailUnique(),
                    errorMessage: "Another account has already been associated with the email")
                .Validate();
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
            ValidUtils.CreatePasswordValidator((IValidator)source, args, Password).Validate();
        }

        protected void ConfirmPasswordTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(ConfirmPassword),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => ConfirmPassword == Password,
                    errorMessage: "Password confirmation does not match")
                .Validate();
        }

        protected void TosCbCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = TosCb.Checked;
        }
    }
}