﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Presenters.Publish.Album.Track;
using LokalMusic._Code.Repositories.Publish.Album.Track;
using LokalMusic._Code.Views.Publish;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Publish.Album.Track
{
    public partial class AddTrack : System.Web.UI.Page, IAddTrackViewModel
    {
        private AddTrackPresenter Presenter;
        private string AlbumId => NavigationHelper.GetRouteValue("AlbumId").ToString();

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
        public IList<string> Genres { get; set; }
        public HttpPostedFile UploadedTrackFile => trackFile.PostedFile;
        public HttpPostedFile UploadedClipFile => clipFile.PostedFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
            ValidateMaxTrackCount();
            GetGenreItems();
        }

        private void ValidateMaxTrackCount()
        {
            bool maxReached = Presenter.ValidateMaxTrackCount();

            if (maxReached)
            {
                addBtn.Enabled = false;
                maxAlert.Visible = true;
            }
            else
            {
                addBtn.Enabled = true;
                maxAlert.Visible = false;
            }
        }

        private void GetGenreItems()
        {
            Presenter.GetGenreList();

            var builder = new System.Text.StringBuilder();
            foreach (string genre in Genres)
                builder.Append(String.Format("<option value='{0}'>", genre));
            genres.InnerHtml = builder.ToString();
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
            NavigationHelper.Redirect("~/Publish/Album/" + AlbumId);
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

        protected void trackFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => trackFile.HasFile,
                    errorMessage: "Please upload a track file")
                .Validate();
        }

        protected void clipFileCv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            new ValidationHelper((IValidator)source, args)
                .AddRule(
                    rule: () => clipFile.HasFile,
                    errorMessage: "Please upload a clip file")
                .Validate();
        }

    }
}