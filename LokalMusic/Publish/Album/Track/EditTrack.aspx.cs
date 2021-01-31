﻿using LokalMusic._Code.Helpers;
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
        public HttpPostedFile UploadedTrackFile => trackFile.PostedFile;
        public HttpPostedFile UploadedClipFile => clipFile.PostedFile;

        public bool TrackIsUpdated { get; set; }
        public bool ClipIsUpdated { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.PageLoad();

                viewTracks.HRef = "~/Publish/Album/" + AlbumId;
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
            Presenter.LoadTrackDetails();
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

        protected void unlistBtn_Click(object sender, EventArgs e)
        {
            Presenter.UnlistTrack();
            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
        }
    }
}