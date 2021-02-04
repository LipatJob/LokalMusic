using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Admin
{
    public partial class Signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(BackendAuthenticationHelper.LoggedIn)
            {
                BackendAuthenticationHelper.ClearUserSession();
            }
            NavigationHelper.Redirect("~/Admin/Login");
        }
    }
}