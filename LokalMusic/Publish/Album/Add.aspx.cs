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
            dateReleasedTxt.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
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