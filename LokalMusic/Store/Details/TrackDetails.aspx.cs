using LokalMusic._Code.Models.Store.Details;
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
        protected Track trackDetails;

        public TrackDetails()
        {
            this.presenter = new TrackDetailsPresenter(new ProductDetailsRepository());

            // get url
            trackDetails = this.presenter.GetTrackDetails(5, 4, 6);

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            List<Track> tempTracks = new List<Track>();
            tempTracks.Add(this.trackDetails);
            trackContainer.DataSource = tempTracks;
            trackContainer.DataBind();
        }
    }
}