using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Repositories.Store;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store
{
    public partial class Home : System.Web.UI.Page, IHomeViewModel
    {

        // private Model modelName;
        // public Model ModelName { get {return this.modelName;} set { this.modelName = value; }

        private HomePresenter presenter;

        public List<ArtistSummary> topArtists;
        public List<AlbumSummary> bestSellingAlbums;
        public List<TrackSummary> famousTracks;

        public Home()
        {
            this.presenter = new HomePresenter(this, new StoreRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // bind url to view links
            albumViewAll.HRef = $"~/Store/Albums/{"PR"}/{"ASC"}";
            //artistViewAll.HRef = $"~/Store/Artist/{"DA"}/{"DESC"}";
            trackViewAll.HRef = $"~/Store/Tracks/{"PR"}/{"ASC"}";

            this.bestSellingAlbums = this.presenter.GetBestSellingAlbums();
            this.topArtists = this.presenter.GetTopArtists();
            this.famousTracks = this.presenter.GetFamousTracks();

            this.BindModels();
        }

        private void BindModels()
        {
            // Albums
            albumContainer.DataSource = this.bestSellingAlbums;
            albumContainer.DataBind();

            // Artist
            artistContainer.DataSource = this.topArtists;
            artistContainer.DataBind();

            // Track
            trackContainer.DataSource = this.famousTracks;
            trackContainer.DataBind();
        }

        
    }
}