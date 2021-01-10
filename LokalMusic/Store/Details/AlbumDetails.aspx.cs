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

        public AlbumDetails()
        {
            this.presenter = new AlbumDetailsPresenter(new ProductDetailsRepository());

            //urk
            this.albumDetails = this.presenter.GetAlbumDetails(4, 6);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Album> temp = new List<Album>();
            temp.Add(this.albumDetails);
            albumContainer.DataSource = temp;
            albumContainer.DataBind();
        }
    }
}