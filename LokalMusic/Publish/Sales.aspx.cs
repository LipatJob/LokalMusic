﻿using LokalMusic._Code.Models.Publish;
using LokalMusic._Code.Presenters.Publish;
using LokalMusic._Code.Repositories.Publish;
using System;

namespace LokalMusic.Publish
{
    public partial class Sales : System.Web.UI.Page
    {
        private SalesPresenter Presenter;
        public SalesModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter.PageLoad();
            Model = Presenter.GetSalesModel();
            ArtistName.Text = Model.ArtistName;
            SalesItemRepeater.DataSource = Model.SalesItems;
            SalesItemRepeater.DataBind();
        }

        public Sales()
        {
            Presenter = new SalesPresenter(this, new SalesRepository());
        }
    }
}