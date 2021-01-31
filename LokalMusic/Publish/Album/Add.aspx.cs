using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Album;
using LokalMusic._Code.Presenters.Publish.Album;
using LokalMusic._Code.Repositories.Publish.Album;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Publish.Album
{
    public partial class Add : System.Web.UI.Page, IAddAlbumViewModel
    {
        private AddAlbumPresenter Presenter;

        public Add()
        {
            Presenter = new AddAlbumPresenter(this, new AddAlbumRepository());
        }

        public string ArtistName { get => artistName.Text; set => artistName.Text = value; }
        public string AlbumName { get => albumNameTxt.Text; }
        public string Description { get => descriptionTxt.Text; }
        public DateTime DateReleased { get => Convert.ToDateTime(dateReleasedTxt.Text); }
        public string Producer { get => producerTxt.Text; }
        public decimal Price { get => decimal.Parse(priceTxt.Text); }
        public string AlbumCover { get => albumCoverPreview.ImageUrl; set => albumCoverPreview.ImageUrl = value; }
        public HttpPostedFile UploadedAlbumCover => albumCoverFile.PostedFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {                
                int AlbumId = Presenter.AddAlbum();
                string addTrackLink = "~/Publish/Album/" + AlbumId.ToString() + "/Track/Add";
                NavigationHelper.Redirect(addTrackLink);
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            albumNameTxt.Text = "";
            descriptionTxt.Text = "";
            dateReleasedTxt.Text = "";
            producerTxt.Text = "";
            priceTxt.Text = "";
            albumCoverPreview.ImageUrl = @"~\Content\Images\default_cover.jpg";
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

        protected void albumCoverFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => albumCoverFile.HasFile,
                    errorMessage: "Please upload an album cover")
                .Validate();
        }
    }
}