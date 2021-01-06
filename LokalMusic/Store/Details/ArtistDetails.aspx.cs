using LokalMusic._Code.Presenters.Store.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store.Details
{
    public partial class ArtistDetails : System.Web.UI.Page
    {

        protected ArtistDetailsPresenter presenter;

        public ArtistDetails()
        {
            this.presenter = new ArtistDetailsPresenter();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}