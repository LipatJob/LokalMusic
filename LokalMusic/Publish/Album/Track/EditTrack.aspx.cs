using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album.Track;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace LokalMusic.Publish.Album.Track
{
    public partial class EditTrack : System.Web.UI.Page, IEditTrackViewModel
    {
        private EditTrackPresenter Presenter;
        private string AlbumId;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.PageLoad();

                AlbumId = NavigationHelper.GetRouteValue("AlbumId").ToString();
                viewTracks.HRef = "~/Publish/Album/" + AlbumId;
            }
        }

        protected void uploadTrackFileBtn_Click(object sender, EventArgs e)
        {
            if (trackFile.HasFile)
            {
                var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(trackFile.PostedFile));
                TrackFileDuration = tfile.Properties.Duration;
                Response.Write(TrackFileDuration);

                string fileName = AuthenticationHelper.UserId.ToString() + "_" + trackFile.PostedFile.FileName;
                string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile.PostedFile);
                TrackFile = fileLocation;
            }
        }

        protected void uploadClipFileBtn_Click(object sender, EventArgs e)
        {
            if (clipFile.HasFile)
            {
                var tfile = TagLib.File.Create(new HttpPostedFileAbstraction(clipFile.PostedFile));
                ClipFileDuration = tfile.Properties.Duration;
                Response.Write(ClipFileDuration);

                string fileName = AuthenticationHelper.UserId.ToString() + "_" + clipFile.PostedFile.FileName;
                string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.CLIPS_CONTAINER_NAME, clipFile.PostedFile);
                ClipFile = fileLocation;
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Presenter.EditTrack();
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Presenter.LoadTrackDetails();
        }

        protected void unlistBtn_Click(object sender, EventArgs e)
        {
            Presenter.UnlistTrack();
            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
        }
    }
}