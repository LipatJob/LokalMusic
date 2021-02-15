using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using System;
using System.Collections.Generic;

namespace LokalMusic.Store
{
    public partial class ArtistsPage : System.Web.UI.Page
    {
        private ArtistsPagePresenter presenter;
        protected List<ArtistSummary> artists;

        public ArtistsPage()
        {
            this.presenter = new ArtistsPagePresenter(new StoreRepository());
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // handle url request
                string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
                string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

                if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                    this.artists = presenter.GetArtists();
                else
                    this.artists = presenter.GetArtists(sortby, orderby);

                // bind model to view
                artistContainer.DataSource = this.artists;
                artistContainer.DataBind();
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