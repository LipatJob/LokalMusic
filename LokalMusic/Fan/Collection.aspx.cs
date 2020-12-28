using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Presenters.Fan;
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
        public ICollection<CollectionItem> Model { get { return presenter.model;  } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}