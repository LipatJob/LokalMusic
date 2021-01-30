using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album.Track;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Publish.Album.Track
{
    public partial class AddTrack : System.Web.UI.Page, IAddTrackViewModel
    {
        private AddTrackPresenter Presenter;
        private string AlbumId;

        public AddTrack()
        {
            Presenter = new AddTrackPresenter(this, new AddTrackRepository());
        }

        public string ArtistName { get => artistName.Text; set => artistName.Text = value; }
        public string AlbumName { get => albumName.Text; set => albumName.Text = value; }
        public string TrackName { get => trackNameTxt.Text; }
        public string Genre { get => genreTxt.Text; }
        public string Description { get => descriptionTxt.Text; }
        public decimal Price { get => decimal.Parse(priceTxt.Text); }
        public string TrackFile { get => trackSource.Src; set => trackSource.Src = value; }
        public TimeSpan TrackFileDuration { get; set; }
        public string ClipFile { get => clipSource.Src; set => clipSource.Src = value; }
        public TimeSpan ClipFileDuration { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();

            AlbumId = NavigationHelper.GetRouteValue("AlbumId").ToString();
            viewTracks.HRef = "~/Publish/Album/" + AlbumId;
        }

        protected void uploadTrackFileBtn_Click(object sender, EventArgs e)
        {
            if (trackFile.HasFile)
            {
                //string fileName = AuthenticationHelper.UserId.ToString() + "_" + trackFile.PostedFile.FileName;
                //string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile.PostedFile);
                //TrackFile = fileLocation;

                using (var file = new DisposableHttpPostedFileWrapper(trackFile.PostedFile))
                {
                    var tfile = TagLib.File.Create(file.fileLocation);
                    TrackFileDuration = tfile.Properties.Duration;
                }
                Response.Write(TrackFileDuration.TotalSeconds);
            }
        }

        protected void uploadClipFileBtn_Click(object sender, EventArgs e)
        {
            if (clipFile.HasFile)
            {
                // string fileName = AuthenticationHelper.UserId.ToString() + "_" + trackFile.PostedFile.FileName;
                // string fileLocation = FileSystemHelper.UploadFile(fileName, FileSystemHelper.TRACKS_CONTAINER_NAME, trackFile.PostedFile);
                // ClipFile = fileLocation;
                // ClipFileDuration = new TimeSpan(0, 1, 0);
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Presenter.AddTrack();
                NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
            }
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            trackNameTxt.Text = "";
            genreTxt.Text = "";
            descriptionTxt.Text = "";
            priceTxt.Text = "";

        }
    }

    public class DisposableHttpPostedFileWrapper: IDisposable
    {
        public HttpPostedFile file { get; private set; }
        public string fileLocation { get; private set; }
        public DisposableHttpPostedFileWrapper(HttpPostedFile file)
        {
            fileLocation = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads"), System.Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
            file.SaveAs(fileLocation);
        }

        public void Dispose()
        {
            File.Delete(fileLocation);
        }
    }
}