using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store
{
    public partial class CataloguePage : System.Web.UI.Page
    {
        protected List<CatalogueItem> catalogueItems;
        protected CataloguePagePresenter presenter;
        public CataloguePage()
        {
            this.presenter = new CataloguePagePresenter(new StoreRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // handle url request
            // get parameters
            string searchValue = (string)NavigationHelper.GetRouteValue("SearchVal");

            this.catalogueItems = this.presenter.GetSearchedProducts(searchValue);

            productContainer.DataSource = this.catalogueItems;
            productContainer.DataBind();
        }
    }
}