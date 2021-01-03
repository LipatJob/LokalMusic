using LokalMusic._Code.Helpers;
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
    public partial class AlbumsPage : System.Web.UI.Page, IAlbumsPage
    {
        private AlbumsPagePresenter presenter;
        protected List<AlbumSummary> albums;

        public AlbumsPage()
        {
            this.presenter = new AlbumsPagePresenter(this, new StoreRepository());

            string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
            string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

            if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                this.albums = presenter.GetAlbums();
            else
                this.albums = presenter.GetAlbums(sortby, orderby);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            albumContainer.DataSource = this.albums;
            albumContainer.DataBind();
        }
    }
}