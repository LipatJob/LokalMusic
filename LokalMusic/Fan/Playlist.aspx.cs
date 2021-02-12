using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Presenters.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic
{
    public partial class Playlist : System.Web.UI.Page
    {

        protected PlaylistPresenter presenter;
        protected List<PlaylistAlbum> albums;
        public Playlist()
        {
            presenter = new PlaylistPresenter();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!AuthenticationHelper.LoggedIn)
            {
                NavigationHelper.RedirectReturnAddress("~/Account/Login.aspx");
            }
            else
            {
                UserSeperatorHelper.AllowFrontendUsers();

                collectionLink.HRef = "~/Fan/" + AuthenticationHelper.Username;

                albums = presenter.GetAlbums();

                List<PlaylistAlbum> partition1;
                List<PlaylistAlbum> partition2;

                (partition1, partition2) = presenter.PartitionPlaylist(albums);

                // bind model to view
                partition1AlbumContainer.DataSource = partition1;
                partition1AlbumContainer.DataBind();

                partition2AlbumContainer.DataSource = partition2;
                partition2AlbumContainer.DataBind();
            }
        }
    }
}