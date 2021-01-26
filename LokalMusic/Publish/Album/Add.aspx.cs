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

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
        }

        protected void uploadPictureBtn_Click(object sender, EventArgs e)
        {
            if (albumCoverFile.HasFile)
            {
                string fileName = AuthenticationHelper.UserId.ToString() + "_" + albumCoverFile.PostedFile.FileName;
                string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.PICTURE_CONTAINER_NAME, albumCoverFile.PostedFile, true);
                AlbumCover = fileLocation;
            }
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
    }
}