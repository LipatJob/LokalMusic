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

        public ArtistDetails()
        {
            this.presenter = new ArtistDetailsPresenter(new ProductDetailsRepository());

            this.artistDetails = this.presenter.GetArtistDetails(6);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Artist> temp = new List<Artist>();
            temp.Add(this.artistDetails);
            artistContainer.DataSource = temp;
            artistContainer.DataBind();
        }
    }
}