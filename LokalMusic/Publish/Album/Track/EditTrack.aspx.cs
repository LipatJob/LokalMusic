using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album.Track;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace LokalMusic.Publish.Album.Track
{
    public partial class EditTrack : System.Web.UI.Page, IEditTrackViewModel
    {
        private EditTrackPresenter Presenter;
        private string AlbumId => NavigationHelper.GetRouteValue("AlbumId").ToString();

        public EditTrack()
        {
            Presenter = new EditTrackPresenter(this, new EditTrackRepository());
        }

        public string ArtistName { get => artistName.Text; set => artistName.Text = value; }
        public string AlbumName { get => albumName.Text; set => albumName.Text = value; }
        public string TrackName { get => trackNameTxt.Text; set => trackNameTxt.Text = value; }
        public string Genre { get => genreTxt.Text; set => genreTxt.Text = new CultureInfo("en").TextInfo.ToTitleCase(value.ToLower()); }
        public string Description { get => descriptionTxt.Text; set => descriptionTxt.Text = value; }
        public decimal Price { get => decimal.Parse(priceTxt.Text); set => priceTxt.Text = String.Format("{0:N}", value); }
        public string TrackFile { get => trackSource.Src; set => trackSource.Src = value; }
        public TimeSpan TrackFileDuration { get; set; }
        public string ClipFile { get => clipSource.Src; set => clipSource.Src = value; }
        public TimeSpan ClipFileDuration { get; set; }
        public string Status { get; set; }
        public HttpPostedFile UploadedTrackFile => trackFile.PostedFile;
        public HttpPostedFile UploadedClipFile => clipFile.PostedFile;

        public bool TrackIsUpdated { get; set; }
        public bool ClipIsUpdated { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.PageLoad();
                SetPublishUnpublishBtn();

                priceTxt_TextChanged(priceTxt, EventArgs.Empty);
            }
        }

        private void SetPublishUnpublishBtn()
        {
            if (Status == "PUBLISHED")
            {
                publishUnpublishBtn.Text = "Unpublish";
                publishUnpublishBtn.Enabled = true;
            }
            else
            {
                publishUnpublishBtn.Text = "Publish";

                bool albumIsPublished = Presenter.GetAlbumIsPublished();
                if (albumIsPublished)
                    publishUnpublishBtn.Enabled = true;
                else
                    publishUnpublishBtn.Enabled = false;
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (trackFile.HasFile)
                    TrackIsUpdated = true;
                else
                    TrackIsUpdated = false;

                if (clipFile.HasFile)
                    ClipIsUpdated = true;
                else
                    ClipIsUpdated = false;

                Presenter.EditTrack();
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
        }

        protected void withdrawBtn_Click(object sender, EventArgs e)
        {
            Presenter.WithdrawTrack();
            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
        }

        protected void publishUnpublishBtn_Click(object sender, EventArgs e)
        {
            string status = Presenter.GetTrackStatus();

            if (status == "PUBLISHED")
            {
                Presenter.UnpublishTrack();
            }
            else
            {
                saveBtn_Click(saveBtn, EventArgs.Empty);
                Presenter.PublishTrack();
            }

            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
        }

        protected void trackNameTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(TrackName),
                    errorMessage: "Please enter a track name")
                .Validate();
        }

        protected void priceTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(priceTxt.Text),
                    errorMessage: "Please enter the album price")
                .AddRule(
                    rule: ValidUtils.IsValidPrice(priceTxt.Text),
                    errorMessage: "Price should be more than zero")
                .AddRule(
                    rule: () => decimal.Parse(priceTxt.Text) < (decimal)214748.3647,
                    errorMessage: "Price can't be more than 214,748.3647")
                .Validate();
        }

        protected void trackFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => trackFile.HasFile,
                    errorMessage: "Please upload a track file")
                .Validate();
        }

        protected void clipFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => clipFile.HasFile,
                    errorMessage: "Please upload a clip file")
                .Validate();
        }

        protected void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(priceTxt.Text, out decimal priceInput))
            {
                decimal feeAmount = priceInput * 0.15m;
                decimal earningsAmount = priceInput - feeAmount;

                earnings.Text = earningsAmount.ToString("N2");
                transactionFee.Text = feeAmount.ToString("N2");
            }
            else
            {
                earnings.Text = "0.00";
                transactionFee.Text = "0.00";
            }
        }
    }
}