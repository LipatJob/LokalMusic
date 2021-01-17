using LokalMusic._Code.Models.Publish.Albums;
using LokalMusic._Code.Presenters.Publish.Albums;
using LokalMusic._Code.Repositories.Publish.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        public Tracks()
        {
            Presenter = new TracksPresenter(this, new TracksRepository());
        }
    }
}