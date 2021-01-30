using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;

namespace LokalMusic.Store
{
    public partial class ArtistsPage : System.Web.UI.Page, IArtistsPage
    {
        private ArtistsPagePresenter presenter;
        protected List<ArtistSummary> artists;

        public ArtistsPage()
        {
            this.presenter = new ArtistsPagePresenter(this, new StoreRepository());

            string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
            string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

            if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                this.artists = presenter.GetArtists();
            else
                this.artists = presenter.GetArtists(sortby, orderby);
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            artistContainer.DataSource = this.artists;
            artistContainer.DataBind();
        }
    }
}