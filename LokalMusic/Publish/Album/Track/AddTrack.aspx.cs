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
        public HttpPostedFile UploadedTrackFile => trackFile.PostedFile;
        public HttpPostedFile UploadedClipFile => clipFile.PostedFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();

            AlbumId = NavigationHelper.GetRouteValue("AlbumId").ToString();
            viewTracks.HRef = "~/Publish/Album/" + AlbumId;
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
            decimal validDecimal;

            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: ValidUtils.IsNotEmpty(priceTxt.Text),
                    errorMessage: "Please enter the track price")
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