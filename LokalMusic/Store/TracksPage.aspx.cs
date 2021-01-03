using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store
{
    public partial class TracksPage : System.Web.UI.Page, ITracksPage
    {
        private TracksPagePresenter presenter;
        public List<TrackSummary> tracks;
        public TracksPage()
        {
            this.presenter = new TracksPagePresenter(this, new StoreRepository());

            string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
            string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

            if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                this.tracks = presenter.GetTracks();
            else 
                this.tracks = presenter.GetTracks(sortby, orderby);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            trackContainer.DataSource = this.tracks;
            trackContainer.DataBind();
        }
    }
}