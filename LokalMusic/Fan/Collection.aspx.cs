using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Presenters.Fan;
using LokalMusic._Code.Repositories.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Fan
{
    public partial class Collection : System.Web.UI.Page
    {
        private CollectionPresenter presenter;
        public CollectionModel Model { get { return presenter.model;  } }
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CollectionPresenter(new CollectionRepository());
            presenter.InitializeModel();
            Title = Model.Username;
        }
    }
}