using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Presenters.Admin;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace LokalMusic.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductsPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ProductsPresenter(this);
        }

        [WebMethod]
        public static IList<ProductItem> GetProductList()
        {
            return ProductsPresenter.GetProductList();
        }

        [WebMethod]
        public static bool WithdrawItem(int productId)
        {
            ProductsPresenter.WithdrawItem(productId);
            return true;
        }

        [WebMethod]
        public static bool RepublishItem(int productId)
        {
            ProductsPresenter.RepublishItem(productId);
            return true;
        }


    }
}