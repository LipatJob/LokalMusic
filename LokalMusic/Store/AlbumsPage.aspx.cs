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
        public AlbumsPage()
        {
            this.presenter = new AlbumsPagePresenter(this, new StoreRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}