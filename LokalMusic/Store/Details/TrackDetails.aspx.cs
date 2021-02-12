using LokalMusic._Code.Helpers;
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
        }

        private void HandleUrlRequest()
        {
            List<string> urlParams = new List<string>();
            List<int> parsedParams = new List<int>();

            urlParams.Add((string)NavigationHelper.GetRouteValue("TrackId"));
            urlParams.Add((string)NavigationHelper.GetRouteValue("AlbumId"));
            urlParams.Add((string)NavigationHelper.GetRouteValue("ArtistId"));

            // if the physical location is accessed without the expected url format
            urlParams.ForEach(m=>{ if (m == null) InvalidRequest(); });

            int tempParam = 0;
            foreach (string param in urlParams)
            {
                int.TryParse(param, out tempParam);
                parsedParams.Add( tempParam );
                tempParam = 0;
            }
                
            // call presenter to update model
            trackDetails = this.presenter.GetTrackDetails(
                parsedParams[0],
                parsedParams[1],
                parsedParams[2]
                );

            if (this.trackDetails == null)
                this.InvalidRequest();
        }

        private void InvalidRequest()
        {
            NavigationHelper.Redirect("~/Store/TracksPage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserSeperatorHelper.AllowFrontendUsers();

            this.HandleUrlRequest();

            // bind model to view
            List<Track> tempTracks = new List<Track>();
            tempTracks.Add(this.trackDetails);
            trackContainer.DataSource = tempTracks;
            trackContainer.DataBind();
        }
    }
}