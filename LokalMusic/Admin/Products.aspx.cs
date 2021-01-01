using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Presenters.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        public static bool Unlist(int productId)
        {
            ProductsPresenter.UnlistItem(productId);
            return true;
        }

        [WebMethod]
        public static bool Relist(int productId)
        {
            ProductsPresenter.RelistItem(productId);
            return true;
        }


    }
}