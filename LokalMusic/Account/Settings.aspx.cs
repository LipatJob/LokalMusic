using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Presenters.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Data;
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

        public HttpPostedFile UploadedProfilePicture => ProfilePictureFile.PostedFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.PageLoad();
            
            if(IsPasswordChanged())
            {
                ShowPasswordChangedMessage();
            }
            else if(IsProfileImageChanged())
            {
                ShowProfileImageChangedMessage();
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
        
        private void ShowProfileImageChangedMessage()
        {
            changeProfilePictureAlert.Visible = true;
            changeProfilePictureMessage.InnerText = "Successfully changed Password";
        }
        
        private void ShowPasswordChangedMessage()
        {
            changePasswordSuccessAlert.Visible = true;
            changePasswordSuccessMessage.InnerText = "Successfully changed Password";
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
                .AddRule((ValidationHelper.IsNotEqualTo(OldPassword.Length, 0), "This is a required field"))
                .AddRule((() => presenter.CheckOldPassword(), "Please check your old password"))
                .Execute(); ;
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


        protected void submitProfilePicture_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                presenter.UpdateProfilePicture();
            }
        }


        protected void ProfilePictureFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var validator = (CustomValidator)source;
            Response.Write("<script> alert('Hello World') <script/>");
            if(ProfilePictureFile.HasFile == false)
            {
                validator.ErrorMessage = "This is a required field";
                args.IsValid = false;
            }
            else if(ProfilePictureFile.PostedFile.ContentLength > 10485760)
            {
                validator.ErrorMessage = "Please upload a file less than 10MB";
                args.IsValid = false;
            }
            else if(IsValidImage(UploadedProfilePicture) == false)
            {
                validator.ErrorMessage = "Please select an image";
                args.IsValid = false;
            }
            else if (IsImageDimensionValid(UploadedProfilePicture) == false)
            {
                validator.ErrorMessage = "Image must be at least 200px by 200px";
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
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