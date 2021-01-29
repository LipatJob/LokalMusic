using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Cart;
using LokalMusic._Code.Presenters.Cart;
using LokalMusic._Code.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Cart
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected CartPresenter presenter;

        protected List<CartAlbum> albums;
        protected List<CartArtist> artists; // this model contains the tracks

        public CartPage()
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please login or create an account first.');window.location.href='Cart/CartPage.aspx';", true);
            this.presenter = new CartPresenter(new CartRepository());

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.PageLoad();

            this.albums = this.presenter.GetCartAlbums();

            this.artists = this.presenter.GetCartArtists();

            this.BindModel();
        }

        protected void BindModel()
        {
            //albums
            albumContainer.DataSource = this.albums;
            albumContainer.DataBind();

            // artist with their tracks
            artistsContainer.DataSource = this.artists;
            artistsContainer.DataBind();
        }

    }
}