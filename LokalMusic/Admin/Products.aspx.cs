using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Presenters.Admin;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace LokalMusic.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductsPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ProductsPresenter(this);

            if (!Page.IsPostBack) { Bind(); }
        }

        private void Bind()
        {
            GridViewHelper.BindDataTable(ProductsGridView, presenter.GetProductList());

        }

        public string GetMarketPage(string productType, int artistId, int albumId, int productId)
        {
            if (productType.ToLower() == "album")
            {
                return NavigationHelper.CreateAbsoluteUrl($"/Store/{artistId}/{productId}");
            }
            return NavigationHelper.CreateAbsoluteUrl($"/Store/{artistId}/{albumId}/{productId}");
        }

        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "UnlistRepublish")
            {
                presenter.UnlistRepublishProduct(int.Parse(e.CommandArgument.ToString()));
                Bind();
            }
        }
    }
}