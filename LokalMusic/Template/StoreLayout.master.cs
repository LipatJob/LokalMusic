using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Template
{
    public partial class StoreLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CollectionLink.HRef = $"~/Fan/{AuthenticationHelper.Username}";
        }

        protected void Search(object sender, EventArgs e)
        {
            
        }
    }
}