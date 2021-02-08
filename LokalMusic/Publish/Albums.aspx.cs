using LokalMusic._Code.Models.Publish;
using LokalMusic._Code.Presenters;
using LokalMusic._Code.Repositories.Publish;
using System;

namespace LokalMusic.Publish
{
    public partial class Albums : System.Web.UI.Page
    {
        private AlbumsPresenter Presenter;
        public AlbumsModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
            Model = Presenter.GetAlbumsModel();
            ArtistName.Text = Model.ArtistName;
            AlbumItemRepeater.DataSource = Model.AlbumsItems;
            AlbumItemRepeater.DataBind();

            if (Model.AlbumsItems.Count < 1)
                instruction.Visible = true;
            else
                instruction.Visible = false;
        }

        public Albums()
        {
            Presenter = new AlbumsPresenter(this, new AlbumsRepository());
        }
    }

}