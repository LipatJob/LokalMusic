using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using System;
using System.Collections.Generic;

namespace LokalMusic.Store
{
    public partial class AlbumsPage : System.Web.UI.Page
    {

        private AlbumsPagePresenter presenter;
        protected List<AlbumSummary> albums;

        public AlbumsPage()
        {
            this.presenter = new AlbumsPagePresenter(new StoreRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // handle url request
                string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
                string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");

                if ((sortby == null || sortby == "") && (orderby == null || orderby == ""))
                    this.albums = presenter.GetAlbums();
                else
                    this.albums = presenter.GetAlbums(sortby, orderby);

                // bind model to view
                albumContainer.DataSource = this.albums;
                albumContainer.DataBind();
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