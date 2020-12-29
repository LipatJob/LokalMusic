﻿using LokalMusic._Code.Models.Products;
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
        private ProductRepository repository;
        public List<Artist> lokalArtist;
        public List<AlbumCollection> bestSellingAlbums;

        public Home()
        {
            this.presenter = new HomePresenter(this, new ProductRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.bestSellingAlbums = this.presenter.GetBestSellingAlbums();
        }

        
    }
}