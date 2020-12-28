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
        public Home()
        {
            this.repository = new ProductRepository();
            this.presenter = new HomePresenter(this, this.repository);

            repository.GetCompleteProductCatalogue();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayProducts();
        }

        private void DisplayProducts()
        {
            // bind model to html
        }
    }
}