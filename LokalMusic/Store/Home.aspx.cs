using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Repositories.Store;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;

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
            albumViewAll.HRef = $"~/Store/Albums/{"s1"}/{"asc"}";
            artistViewAll.HRef = $"~/Store/Artists/{"s1"}/{"asc"}";
            trackViewAll.HRef = $"~/Store/Tracks/{"s1"}/{"asc"}";

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