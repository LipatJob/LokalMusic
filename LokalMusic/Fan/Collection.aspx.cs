using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Presenters.Fan;
using LokalMusic._Code.Repositories.Fan;
using System;

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
            profilePicture.ImageUrl = Model.ProfileImage;

            collectionItemRepeater.DataSource = Model.Collection;
            collectionItemRepeater.DataBind();
        }
    }
}