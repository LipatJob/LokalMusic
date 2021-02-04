using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Account
{
    public partial class Settings : System.Web.UI.Page, ISettingsViewModel
    {
        private string[] validFileFormats = new[]{ ".jpg", ".png", ".gif" };
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
        public string ProfileImage { get => ProfilePictureImg.ImageUrl; set => ProfilePictureImg.ImageUrl = value; }
        public string ArtistBio { get => BioTxt.Text; set => BioTxt.Text = value; }
        public string ArtistName { get => ArtistNameTxt.Text; set => ArtistNameTxt.Text= value; }


        public HttpPostedFile UploadedProfilePicture => ProfilePictureFile.PostedFile;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                presenter.PageLoad();
            }

            if (IsPasswordChanged())
            {
                ShowPasswordChangedMessage();
            }
            else if(IsProfileImageChanged())
            {
                ShowProfileImageChangedMessage();
            }
            else if(IsBioChanged())
            {
                ShowBioChangedMessage();
            }
        }
        private bool IsPasswordChanged()
        {
            return Request.QueryString["PasswordChanged"] == "True";
        }

        private bool IsProfileImageChanged()
        {
            return Request.QueryString["ProfileImageChanged"] == "True";
        }

        private bool IsBioChanged()
        {
            return Request.QueryString["ArtistBioChanged"] == "True";
        }

        private void ShowProfileImageChangedMessage()
        {
            changeProfilePictureAlert.Visible = true;
            changeProfilePictureMessage.InnerText = "Successfully changed Profile Image";
        }

        private void ShowPasswordChangedMessage()
        {
            changePasswordSuccessAlert.Visible = true;
            changePasswordSuccessMessage.InnerText = "Successfully changed Password";
        }

        private void ShowBioChangedMessage()
        {
            changeBioSuccessAlert.Visible = true;
            changeBioSuccessMessage.InnerText = "Successfuly changed Bio ";
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<PaymentHistoryItem> GetPaymentHistory()
        {
            return SettingsPresenter.GetPaymentHistory();
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
            if(Page.IsValid)
            {
                presenter.ChangePassword();
            }
        }

        protected void submitBtnUpdateBio_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                presenter.UpdateBio();
            }
        }


        protected void submitProfilePicture_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                presenter.UpdateProfilePicture();
            }
        }


        protected void ProfilePictureFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => ProfilePictureFile.HasFile,
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => ProfilePictureFile.PostedFile.ContentLength < 10485760,
                    errorMessage: "Please upload a file less than 10MB")
                .AddRule(
                    rule: () => IsValidImage(UploadedProfilePicture),
                    errorMessage: "Please select a valid image")
                .AddRule(
                    rule: () => IsImageDimensionValid(UploadedProfilePicture),
                    errorMessage: "Image must be at least 200px by 200px")
                .Validate();
        }

        private bool IsImageDimensionValid(HttpPostedFile file)
        {
            file.InputStream.Position = 0;
            using (var myImage = System.Drawing.Image.FromStream(file.InputStream))
            {
                return
                    InBetween(myImage.Height, 200, 4000)
                    && InBetween(myImage.Width, 200, 4000);
            }
        }

        private bool IsValidImage(HttpPostedFile file)
        {
            file.InputStream.Position = 0;
            try
            {
                if(validFileFormats.Contains(GetFileType(file.FileName)) == false)
                {
                    return false;
                }
                using (var myImage = System.Drawing.Image.FromStream(file.InputStream))
                {
                    return true;
                }
            }
            catch
            {

                return false;
            }
        }

        private bool InBetween(int value, int min, int max)
        {
            return value <= max && value >= min;
        }

        private string GetFileType(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.'));
        }


    }
}