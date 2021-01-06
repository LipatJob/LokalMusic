using LokalMusic._Code.Presenters.Store.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store.Details
{
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected AlbumDetailsPresenter presenter;

        public AlbumDetails()
        {
            this.presenter = new AlbumDetailsPresenter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}