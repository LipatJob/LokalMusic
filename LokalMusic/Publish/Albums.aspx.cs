using LokalMusic._Code.Models.Publish;
using LokalMusic._Code.Presenters;
using LokalMusic._Code.Repositories.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Publish
{
    public partial class Albums : System.Web.UI.Page
    {
        private AlbumsPresenter Presenter;
        public AlbumsModel Model { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model = Presenter.GetAlbumsModel();
            ArtistName.Text = Model.ArtistName;
            AlbumItemRepeater.DataSource = Model.AlbumsItems;
            AlbumItemRepeater.DataBind();
        }

        public Albums()
        {
            Presenter = new AlbumsPresenter(this, new AlbumsRepository());
        }
    }

}