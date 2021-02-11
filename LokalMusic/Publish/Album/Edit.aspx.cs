using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Publish.Album
{
    public partial class Edit : System.Web.UI.Page, IEditAlbumViewModel
    {
        private EditAlbumPresenter Presenter;

        public Edit()
        {
            Presenter = new EditAlbumPresenter(this, new EditAlbumRepository());
        }

        public string ArtistName { get => artistName.Text; set => artistName.Text = value; }
        public string AlbumName { get => albumNameTxt.Text; set => albumNameTxt.Text = value; }
        public string Description { get => descriptionTxt.Text; set => descriptionTxt.Text = value; }
        public DateTime DateReleased { get => Convert.ToDateTime(dateReleasedTxt.Text); set => dateReleasedTxt.Text = value.ToString("yyyy-MM-dd"); }
        public string Producer { get => producerTxt.Text; set => producerTxt.Text = value; }
        public decimal Price { get => decimal.Parse(priceTxt.Text); set => priceTxt.Text = String.Format("{0:N}", value); }
        public string AlbumCover { get => albumCoverPreview.ImageUrl; set => albumCoverPreview.ImageUrl = value; }
        public HttpPostedFile UploadedAlbumCover => albumCoverFile.PostedFile;
        public bool AlbumCoverIsUpdated { get; set; }
        public string Status { get; set; }
        

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

                bool hasTrack = Presenter.GetAlbumHasTrack();
                if (hasTrack)
                    publishUnpublishBtn.Enabled = true;
                else
                    publishUnpublishBtn.Enabled = false;
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (albumCoverFile.HasFile)
                    AlbumCoverIsUpdated = true;
                else
                    AlbumCoverIsUpdated = false;

                Presenter.EditAlbum();
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            NavigationHelper.Redirect("~/Publish/Albums");
        }

        protected void withdrawBtn_Click(object sender, EventArgs e)
        {
            Presenter.WithdrawAlbum();
            NavigationHelper.Redirect("~/Publish/Albums");
        }

        protected void publishUnpublishBtn_Click(object sender, EventArgs e)
        {
            string status = Presenter.GetAlbumStatus();

            if (status == "PUBLISHED")
            {
                Presenter.UnpublishAlbum();
            }
            else
            {
                saveBtn_Click(saveBtn, EventArgs.Empty);
                Presenter.PublishAlbum();
            }

            NavigationHelper.Redirect("~/Publish/Albums");
        }

        protected void albumNameTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(AlbumName),
                    errorMessage: "Please enter an album name")
                .Validate();
        }

        protected void dateReleasedTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(dateReleasedTxt.Text),
                    errorMessage: "Please enter the release date")
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