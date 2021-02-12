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
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected AlbumDetailsPresenter presenter;
        protected Album albumDetails;
        protected List<Track> tracks;

        public AlbumDetails()
        {
            this.presenter = new AlbumDetailsPresenter(new ProductDetailsRepository());
        }

        private void HandleUrlRequest()
        {
            List<string> urlParams = new List<string>();
            List<int> parsedParams = new List<int>();

            urlParams.Add((string)NavigationHelper.GetRouteValue("AlbumId"));
            urlParams.Add((string)NavigationHelper.GetRouteValue("ArtistId"));

            // if the physical location is accessed without the expected url format
            urlParams.ForEach(m => { if (m == null) InvalidRequest(); });

            int tempParam = 0;
            foreach (string param in urlParams)
            {
                int.TryParse(param, out tempParam);
                parsedParams.Add(tempParam);
                tempParam = 0;
            }

            // call presenter to update model
            this.albumDetails = this.presenter.GetAlbumDetails(
                parsedParams[0],
                parsedParams[1]
                );

            if (this.albumDetails == null)
                this.InvalidRequest();
            else 
             this.tracks = this.presenter.GetTracksOfAlbum(
                 parsedParams[0],
                 parsedParams[1]
                 );
        }

        private void InvalidRequest()
        {
            NavigationHelper.Redirect("~/Store/AlbumsPage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserSeperatorHelper.AllowFrontendUsers();

                this.HandleUrlRequest();

                // populate models' additional information
                this.presenter.DetermineTrackSummaries(albumDetails, tracks);


                // bind modesl to view
                List<Album> temp = new List<Album>();
                temp.Add(this.albumDetails);
                albumContainer.DataSource = temp;
                albumContainer.DataBind();

                tracksContainer.DataSource = this.tracks;
                tracksContainer.DataBind();
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