﻿using LokalMusic._Code.Helpers;
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
            tracks_page.HRef = $"~/Store/Tracks/{"RA"}/{"ASC"}";
            albums_page.HRef = $"~/Store/Albums/{"RA"}/{"ASC"}";
            //artist.HRef = $"~/Store/Tracks/{"RA"}/{"ASC"}";
        }

        
        protected void filterBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('"+ this.sortBy + "-" + this.orderBy + "');", true);
        }
    }
}