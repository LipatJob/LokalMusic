using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Repositories.Store;
using System;
using System.Collections.Generic;

namespace LokalMusic.Store
{
    public partial class Home : System.Web.UI.Page
    {

        private HomePresenter presenter;

        public IList<ArtistSummary> topArtists;
        public IList<AlbumSummary> bestSellingAlbums;
        public IList<TrackSummary> famousTracks;
        public IList<FeaturedProduct> featuredProducts;

        public Home()
        {
            this.presenter = new HomePresenter(new StoreRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // bind url to view links
                albumViewAll.HRef = $"~/Store/Albums/{"s1"}/{"asc"}";
                artistViewAll.HRef = $"~/Store/Artists/{"s1"}/{"asc"}";
                trackViewAll.HRef = $"~/Store/Tracks/{"s1"}/{"asc"}";

                this.bestSellingAlbums = this.presenter.GetBestSellingAlbums();
                this.topArtists = this.presenter.GetTopArtists();
                this.famousTracks = this.presenter.GetFamousTracks();
                this.featuredProducts = this.presenter.GetFeaturedProducts();

                this.BindModels();
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

        private void BindModels()
        {
            //Featured Products
            FeaturedProductRepeater.DataSource = this.featuredProducts;
            FeaturedProductRepeater.DataBind();

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