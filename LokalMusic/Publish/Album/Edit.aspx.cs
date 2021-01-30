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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.PageLoad();

            }
        }

        protected void uploadPictureBtn_Click(object sender, EventArgs e)
        {
            if (albumCoverFile.HasFile)
            {
                string fileName = AuthenticationHelper.UserId.ToString() + "_" + albumCoverFile.PostedFile.FileName;
                string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.ALBUMCOVER_CONTAINER_NAME, albumCoverFile.PostedFile);
                AlbumCover = fileLocation;
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
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
    }
}