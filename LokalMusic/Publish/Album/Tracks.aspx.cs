﻿using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish.Albums;
using LokalMusic._Code.Presenters.Publish.Albums;
using LokalMusic._Code.Repositories.Publish.Albums;
using System;

namespace LokalMusic.Publish
{
    public partial class Tracks : System.Web.UI.Page
    {
        private TracksPresenter Presenter;

        public TracksModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
            Model = Presenter.GetTracksModel();
            ArtistName.Text = Model.ArtistName;
            AlbumName.Text = Model.AlbumName;
            TrackItemRepeater.DataSource = Model.TracksItems;
            TrackItemRepeater.DataBind();

            int AlbumId = int.Parse((string)NavigationHelper.GetRouteValue("AlbumId"));
            addTrack.HRef = "~/Publish/Album/" + AlbumId + "/Track/Add";

            if (Model.TracksItems.Count < 1)
                instruction.Visible = true;
            else
                instruction.Visible = false;
        }

        public Tracks()
        {
            Presenter = new TracksPresenter(this, new TracksRepository());
        }
    }
}