using LokalMusic._Code.Presenters.Finance;
using LokalMusic._Code.Repositories.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Finance
{
    public partial class ArtistPayment : System.Web.UI.Page
    {
        ArtistPaymentPresenter presenter;
        public ArtistPayment()
        {
            presenter = new ArtistPaymentPresenter(new ArtistPaymentRepository());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        public void Bind()
        {
            PopulateTable(RemainingBalances, presenter.GetRemainingBalances());
            PopulateTable(ArtistPayments, presenter.GetRecentPayments());

        }

        private void PopulateTable(GridView view, DataTable table)
        {
            if(table.Rows.Count == 0)
            {
                return;
            }

            view.DataSource = table;
            view.DataBind();

            view.UseAccessibleHeader = true;
            view.HeaderRow.TableSection = TableRowSection.TableHeader;
            view.GridLines = GridLines.None;
        }

        protected void PayArtistsBtn_Click(object sender, EventArgs e)
        {
            presenter.PayArtists();
            Bind();
        }
    }
}