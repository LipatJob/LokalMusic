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
    public partial class ArtistDetails : System.Web.UI.Page
    {

        protected ArtistDetailsPresenter presenter;
        protected Artist artistDetails;
        protected List<Album> albums;

        public ArtistDetails()
        {
            this.presenter = new ArtistDetailsPresenter(new ProductDetailsRepository());
        }

        private void HandleUrlRequest()
        {
            string urlParam = (string)NavigationHelper.GetRouteValue("ArtistId");

            // if the physical location is accessed without the expected url format
            if (urlParam == null) this.InvalidRequest();

            int parsedParam = 0;
            int.TryParse(urlParam, out parsedParam);   

            // call presenter to update model
            this.artistDetails = this.presenter.GetArtistDetails(parsedParam);

            if (this.artistDetails == null)
                this.InvalidRequest();
            else
                this.albums = this.presenter.GetAlbumsOfArtist(parsedParam);
        }

        private void InvalidRequest()
        {
            NavigationHelper.Redirect("~/Store/ArtistsPage.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.HandleUrlRequest();
            (this.artistDetails, this.albums) = this.presenter.DetermineAristSummary(artistDetails, albums);
            this.albums = this.presenter.DetermineAlbumsSummary(albums);

            List<Artist> temp = new List<Artist>();
            temp.Add(this.artistDetails);
            artistContainer.DataSource = temp;
            artistContainer.DataBind();

            albumsContainer.DataSource = this.albums;
            albumsContainer.DataBind();
        }
    }
}