using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using System;
using System.Collections.Generic;

namespace LokalMusic.Store
{
    public partial class TracksPage : System.Web.UI.Page
    {

        private TracksPagePresenter presenter;
        public List<TrackSummary> tracks;

        public TracksPage()
        {
            this.presenter = new TracksPagePresenter(new StoreRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserSeperatorHelper.AllowFrontendUsers();

                string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
                string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

                if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                    this.tracks = presenter.GetTracks();
                else
                    this.tracks = presenter.GetTracks(sortby, orderby);

                // bind model to view
                trackContainer.DataSource = this.tracks;
                trackContainer.DataBind();
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                NavigationHelper.Redirect("~/Error/Database");
            }
            catch (Exception x)
            {
                NavigationHelper.Redirect("~/Error/Error");
            }
        }
    }
}