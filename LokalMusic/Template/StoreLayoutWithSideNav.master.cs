using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic.Template
{
    public partial class StoreLayoutWithSideNav : System.Web.UI.MasterPage
    {
        private string sortBy;
        private string orderBy;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void filterBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('"+ this.sortBy + "-" + this.orderBy + "');", true);
        }
    }
}