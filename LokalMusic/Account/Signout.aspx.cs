using LokalMusic._Code.Helpers;
using System;

namespace LokalMusic.Account
{
    public partial class Signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(AuthenticationHelper.LoggedIn)
            {
                AuthenticationHelper.ClearUserSession();
            }
            NavigationHelper.Redirect("~/Store/Home");
        }
    }
}