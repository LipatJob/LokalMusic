using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Cart;
using LokalMusic._Code.Presenters.Cart;
using LokalMusic._Code.Repositories.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            this.presenter = new CartPresenter(new CartRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.presenter.PageLoad();
            }
            catch (ThreadAbortException x)
            {
                NavigationHelper.Redirect("~/Store/Home");
            }

            try
            {
                this.albums = this.presenter.GetCartAlbums();
                if (albums != null)
                    this.albums = this.presenter.GetCartAlbumsAdditionalDetails(this.albums);

                this.artists = this.presenter.GetCartArtists();

                this.BindModel();
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