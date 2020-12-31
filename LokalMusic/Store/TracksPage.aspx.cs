using LokalMusic._Code.Models.Products;
using LokalMusic._Code.Presenters.Store;
using LokalMusic._Code.Repositories;
using LokalMusic._Code.Views.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Store
{
    public partial class TracksPage : System.Web.UI.Page, ITracksPage
    {
        private TracksPagePresenter presenter;
        public List<Track> tracks;
        public TracksPage()
        {
            this.presenter = new TracksPagePresenter(this, new StoreRepository());

            // url Store/TracksPage/{SortBy}/{OrderBy}
            this.tracks = presenter.GetTracks(/*sortby, orderby*/);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            trackContainer.DataSource = this.tracks;
            trackContainer.DataBind();
        }
    }
}