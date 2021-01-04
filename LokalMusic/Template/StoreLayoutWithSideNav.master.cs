using LokalMusic._Code.Helpers;
using System;
using System.Web;
using System.Web.UI.WebControls;

namespace LokalMusic.Template
{
    public partial class StoreLayoutWithSideNav : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            tracks_page.HRef = $"~/Store/Tracks/{"s1"}/{"asc"}";
            albums_page.HRef = $"~/Store/Albums/{"s1"}/{"asc"}";
            artists_page.HRef = $"~/Store/Artists/{"s1"}/{"asc"}";
        }

        private void DetermineRoutePage(string sortBy, string orderBy)
        {
            string currentUrl = HttpContext.Current.Request.Url.AbsolutePath;
            string redirectUrl = "";
            if (currentUrl.Contains("Tracks"))
                redirectUrl = "/Store/Tracks/";
            else if (currentUrl.Contains("Albums"))
                redirectUrl = "/Store/Albums/";
            else /*(currentUrl.Contains("Artists"))*/
                redirectUrl = "/Store/Artists/";

            redirectUrl += sortBy + "/" + orderBy;
            NavigationHelper.Redirect("~" + redirectUrl);
        }

        protected void SortClick(object sender, EventArgs e)
        {
            Button sortBtn = (Button)sender;
            string sortCateg = sortBtn.CommandArgument.ToString();
            string orderby = (string)NavigationHelper.GetRouteValue("OrderBy");
            DetermineRoutePage(sortCateg, orderby);
        }
        protected void OrderClick(object sender, EventArgs e)
        {
            Button orderBtn = (Button)sender;
            string orderCateg = orderBtn.CommandArgument.ToString();
            string sortby = (string)NavigationHelper.GetRouteValue("SortBy");
            DetermineRoutePage(sortby, orderCateg);
        }
    }
}