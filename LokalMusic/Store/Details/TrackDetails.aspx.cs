using LokalMusic._Code.Presenters.Store.Details;
using LokalMusic._Code.Repositories.Store.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store.Details
{
    public partial class TrackDetails : System.Web.UI.Page
    {
        private TrackDetailsPresenter presenter;
        public TrackDetails()
        {
            this.presenter = new TrackDetailsPresenter(new ProductDetailsRepository());
        }

        protected string test = "123123";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}