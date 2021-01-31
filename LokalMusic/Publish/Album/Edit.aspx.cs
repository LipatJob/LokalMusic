using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DateTime DateReleased { get => Convert.ToDateTime(dateReleasedTxt.Text); set => dateReleasedTxt.Text = String.Format("{0:MM/dd/yyyy}", value); }
        public string Producer { get => producerTxt.Text; set => producerTxt.Text = value; }
        public decimal Price { get => decimal.Parse(priceTxt.Text); set => priceTxt.Text = String.Format("{0:N}", value); }
        public string AlbumCover { get => albumCoverPreview.ImageUrl; set => albumCoverPreview.ImageUrl = value; }
        public HttpPostedFile UploadedAlbumCover => albumCoverFile.PostedFile;
        public bool AlbumCoverIsUpdated { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.PageLoad();

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
            Presenter.LoadAlbumDetails();
        }

        protected void unlistBtn_Click(object sender, EventArgs e)
        {
            Presenter.UnlistAlbum();
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
                    rule: ValidUtils.IsValidRegex(dateReleasedTxt.Text, @"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"),
                    errorMessage: "Date should be in the format of MM/DD/YYYY")
                .Validate();
        }

        protected void priceTxtCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            decimal validDecimal;

            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(priceTxt.Text),
                    errorMessage: "Please enter the album price")
                .AddRule(
                    rule: () => decimal.TryParse(priceTxt.Text, out validDecimal),
                    errorMessage: "Please enter numbers only")
                .AddRule(
                    rule: ValidUtils.IsValidPrice(priceTxt.Text),
                    errorMessage: "Price should be more than zero")
                .Validate();
        }
    }
}